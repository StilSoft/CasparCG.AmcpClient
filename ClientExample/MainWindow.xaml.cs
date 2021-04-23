//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CasparCg.AmcpClient;
using CasparCg.AmcpClient.Commands.Basic;
using CasparCg.AmcpClient.Commands.Basic.Common;
using CasparCg.AmcpClient.Commands.Cg;
using CasparCg.AmcpClient.Commands.Cg.Common.TemplateData;
using CasparCg.AmcpClient.Commands.Mixer;
using CasparCg.AmcpClient.Commands.Mixer.Common;
using CasparCg.AmcpClient.Commands.Query;
using CasparCg.AmcpClient.Commands.Query.Common;
using CasparCg.AmcpClient.Commands.Query.Common.Info.Template;
using CasparCg.AmcpClient.Commands.Query.Common.Response;
using CasparCg.AmcpClient.Commands.Thumbnail;
using CasparCg.AmcpClient.Commands.Thumbnail.Common;
using CasparCg.AmcpClient.Commands.Thumbnail.Common.Response;
using CasparCg.AmcpClient.Common.Enums;
using StilSoft.Communication.Tcp;

namespace AmcpClientExample
{
    public partial class MainWindow
    {
        private readonly AmcpConnection connection;
        private readonly Version minimumServerVersion = new Version("2.1.0.3344");
        private int? channel;
        private int? layer;

        public MainWindow()
        {
            InitializeComponent();

            this.connection = new AmcpConnection(this.HostNameTextBox.Text)
            {
                AutoConnect = true, AutoReconnect = true, ReconnectAttempts = 5, KeepAliveEnable = true
            };

            this.connection.ConnectionStateChanged += (s, e) => this.Dispatcher.BeginInvoke(new Action(() =>
            {
                DisplayConnectionState(e.State);

                if (e.State == ConnectionState.Connected)
                {
                    LoadServerInfo();
                }
                else
                {
                    ClearServerInfo();
                }
            }));

            this.connection.InternalError += (s, e) => Console.WriteLine(e.Exception.Message);

            LoadTransition();
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.connection.ConnectAsync(this.HostNameTextBox.Text, 5250);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.connection.DisconnectAsync();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void HostNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!this.IsLoaded)
            {
                return;
            }

            this.connection.Hostname = this.HostNameTextBox.Text;
        }

        private void ChannelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.channel = null;

            if (int.TryParse(this.ChannelTextBox.Text, out int channelTmp))
            {
                this.channel = channelTmp;
            }
        }

        private void LayerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.layer = null;

            if (int.TryParse(this.LayerTextBox.Text, out int layerTmp))
            {
                this.layer = layerTmp;
            }
        }

        #region EXAMPLE 4

        private async void LoadThumbnailsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int totalThumbnails = int.Parse(this.LoadTotalThumbnailsTextBox.Text);

                this.LoadThumbnailsButton.IsEnabled = false;
                this.ThumbnailsListView.ItemsSource = null;

                var thumbnailList = new ObservableCollection<ImageSource>();

                this.ThumbnailsListView.ItemsSource = thumbnailList;

                ThumbnailListCommandResponse response =
                    await new ThumbnailListCommand { ResponseTimeout = 10000 }.ExecuteAsync(this.connection);

                foreach (ThumbnailFileInfo thumbnailFileInfo in response.GetThumbnailList())
                {
                    ThumbnailRetrieveCommandResponse response2 =
                        await new ThumbnailRetrieveCommand(thumbnailFileInfo.FullName).ExecuteAsync(this.connection);

                    thumbnailList.Add(ToBitmapImage(response2.GetThumbnailData()));

                    if (--totalThumbnails == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            this.LoadThumbnailsButton.IsEnabled = true;
        }

        #endregion

        private BitmapImage ToBitmapImage(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                memoryStream.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        private void DisplayConnectionState(ConnectionState e)
        {
            SolidColorBrush color = Brushes.Red;

            switch (e)
            {
                case ConnectionState.Connecting:
                case ConnectionState.Reconnecting:
                    color = Brushes.Yellow;
                    break;
                case ConnectionState.Connected:
                    color = Brushes.Green;
                    break;
                case ConnectionState.Disconnected:
                    color = Brushes.Red;
                    break;
            }

            this.ConnectionStateIndicator.Fill = color;
            this.ConnectionStateTextBlock.Text = e.ToString();
        }

        private async void LoadServerInfo()
        {
            try
            {
                Version version = await this.connection.GetServerVersionAsync();

                this.ServerVersionTextBlock.Text = version.ToString();

                if (version < this.minimumServerVersion)
                {
                    ShowMessage($"CasparCG server version {version} currently is not fully supported. " +
                                $"Minimum supported version is {this.minimumServerVersion} or newer.", MessageBoxImage.Warning);
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        private void ClearServerInfo()
        {
            this.ServerVersionTextBlock.Text = "";
        }

        private void ShowMessage(string message, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(message, "Amcp Client Example", MessageBoxButton.OK, messageBoxImage);
        }

        private void ShowException(Exception exception)
        {
            bool includeExceptionType = false;
            bool includeStackTrace = false;
#if DEBUG
            includeExceptionType = true;
            includeStackTrace = true;
#endif
            ShowMessage(GetExceptionTree(exception, includeExceptionType, includeStackTrace), MessageBoxImage.Error);
        }

        private string GetExceptionTree(Exception exception, bool includeExceptionType = false, bool includeStackTrace = false)
        {
            var exceptionString = new StringBuilder();

            while (exception != null)
            {
                exceptionString.AppendLine(exception.Message);

                if (includeExceptionType)
                {
                    exceptionString.AppendLine("Exception type: " + exception.GetType().FullName);
                    exceptionString.AppendLine();
                }

                if (includeStackTrace)
                {
                    exceptionString.AppendLine("Stacktrace:");
                    exceptionString.AppendLine(exception.StackTrace);
                    exceptionString.AppendLine();
                }

                if (!includeExceptionType && !includeStackTrace)
                {
                    exceptionString.AppendLine();
                }

                exception = exception.InnerException;
            }

            return exceptionString.ToString();
        }

        #region EXAMPLE 1

        private void LoadTransition()
        {
            this.TransitionTypeComboBox.Items.Add("None");

            foreach (object transition in Enum.GetValues(typeof(TransitionType)))
            {
                this.TransitionTypeComboBox.Items.Add(transition.ToString());
            }

            this.TransitionTypeComboBox.SelectedIndex = 0;


            foreach (object tween in Enum.GetValues(typeof(Tween)))
            {
                this.TransitionTweenComboBox.Items.Add(tween.ToString());
            }

            this.TransitionTweenComboBox.SelectedIndex = 0;


            foreach (object direction in Enum.GetValues(typeof(Direction)))
            {
                this.TransitionDirectionComboBox.Items.Add(direction.ToString());
            }

            this.TransitionDirectionComboBox.SelectedIndex = 1;
        }

        private async void LoadMediaButton_Click(object sender, RoutedEventArgs e)
        {
            this.LoadMediaButton.IsEnabled = false;
            this.MediaListView.ItemsSource = null;

            try
            {
                ClsCommandResponse response = await new ClsCommand { ResponseTimeout = 10000 }.ExecuteAsync(this.connection);

                this.MediaListView.ItemsSource = response.GetMediaList();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            this.LoadMediaButton.IsEnabled = true;
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.MediaListView.SelectedValue is MediaFileInfo mediaFileInfo))
            {
                return;
            }

            try
            {
                Transition transition = null;

                if (this.TransitionTypeComboBox.SelectedIndex > 0)
                {
                    var transitionType = (TransitionType)Enum.Parse(typeof(TransitionType),
                        this.TransitionTypeComboBox.SelectedValue.ToString());
                    int.TryParse(this.TransitionDurationTextBox.Text, out int transitionDuration);
                    var transitionTween = (Tween)Enum.Parse(typeof(Tween), this.TransitionTweenComboBox.SelectedValue.ToString());
                    var transitionDirection = (Direction)Enum.Parse(typeof(Direction),
                        this.TransitionDirectionComboBox.SelectedValue.ToString());

                    transition = new Transition(transitionType, transitionDuration, transitionTween, transitionDirection);
                }

                await new PlayCommand(this.channel, this.layer, mediaFileInfo.FullName, this.LoopCheckBox.IsChecked)
                {
                    Transition = transition
                }.ExecuteAsync(this.connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await new StopCommand(this.channel, this.layer).ExecuteAsync(this.connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void ClearChannel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await new ClearCommand(this.channel, this.layer).ExecuteAsync(this.connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MediaListView_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            // Quick and dirty :)
            if (!(((ListViewItem)e.Source).Content is MediaFileInfo mediaFileInfo) || 
                !(((ListViewItem)sender).ToolTip is Image img))
            {
                return;
            }

            img.Source = null;

            if (!this.connection.IsConnected())
            {
                return;
            }

            new ThumbnailRetrieveCommand(mediaFileInfo.FullName).ExecuteAsync(this.connection).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    img.Source = ToBitmapImage(task.Result.GetThumbnailData());
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region EXAMPLE 2

        private async void LoadTemplatesButton_Click(object sender, RoutedEventArgs e)
        {
            this.LoadTemplatesButton.IsEnabled = false;
            this.TemplatesListView.ItemsSource = null;

            try
            {
                TlsCommandResponse response = await new TlsCommand { ResponseTimeout = 10000 }.ExecuteAsync(this.connection);

                this.TemplatesListView.ItemsSource = response.GetTemplateList();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            this.LoadTemplatesButton.IsEnabled = true;
        }

        private readonly TemplateDataXml templateDataXml = new TemplateDataXml();

        private async void TemplatesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.templateDataXml.Clear();
            this.TemplateDataPairsComboBox.ItemsSource = null;
            this.TemplateDataPairValueTextBox.Text = "";
            this.AuthorNameTextBlock.Text = "";
            this.AuthorEmailTextBlock.Text = "";
            this.TemplateInfoTextBlock.Text = "";
            this.VersionTextBlock.Text = "";
            this.OriginalHeightTextBlock.Text = "";
            this.OriginalWidthTextBlock.Text = "";



            if (!(this.TemplatesListView.SelectedValue is TemplateFileInfo templateFileInfo) || 
                templateFileInfo.TemplateType != TemplateType.Flash)
            {
                return;
            }

            try
            {
                InfoTemplateCommandResponse response =
                    await new InfoTemplateCommand(templateFileInfo.FullName).ExecuteAsync(this.connection);

                this.AuthorNameTextBlock.Text = response.TemplateInfo.AuthorName;
                this.AuthorEmailTextBlock.Text = response.TemplateInfo.AuthorEmail;
                this.TemplateInfoTextBlock.Text = response.TemplateInfo.TemplateInformation;
                this.VersionTextBlock.Text = response.TemplateInfo.Version;
                this.OriginalHeightTextBlock.Text = response.TemplateInfo.OriginalHeight.ToString();
                this.OriginalWidthTextBlock.Text = response.TemplateInfo.OriginalWidth.ToString();

                foreach (InstanceInfo templateInfoInstance in response.TemplateInfo.Instances)
                {
                    this.templateDataXml.Add(new DataPair(templateInfoInstance.Name, ""));
                }

                foreach (ParameterInfo templateInfoParameter in response.TemplateInfo.Parameters)
                {
                    this.templateDataXml.Add(new DataPair(templateInfoParameter.Id, ""));
                }

                this.TemplateDataPairsComboBox.ItemsSource = this.templateDataXml.GetAll();

                if (this.TemplateDataPairsComboBox.Items.Count > 0)
                {
                    this.TemplateDataPairsComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void LoadAndPlayTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.TemplatesListView.SelectedValue is TemplateFileInfo templateFileInfo))
            {
                return;
            }

            try
            {
                await new CgAddCommand(this.channel, this.layer, 0, templateFileInfo.FullName, true, this.templateDataXml)
                    .ExecuteAsync(this.connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void StopTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await new CgStopCommand(this.channel, this.layer, 0).ExecuteAsync(this.connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void UpdateTemplateDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await new CgUpdateCommand(this.channel, this.layer, 0, this.templateDataXml).ExecuteAsync(this.connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void AddTemplateDataPairButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TemplateDataPairNameTextBox.Text))
            {
                return;
            }

            try
            {
                this.templateDataXml.Add(new DataPair(this.TemplateDataPairNameTextBox.Text, ""));
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            this.TemplateDataPairsComboBox.ItemsSource = null;
            this.TemplateDataPairsComboBox.ItemsSource = this.templateDataXml.GetAll();

            this.TemplateDataPairsComboBox.SelectedIndex = this.TemplateDataPairsComboBox.Items.Count - 1;
            this.TemplateDataPairNameTextBox.Text = "";
        }

        private void RemoveTemplateDataPairButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.TemplateDataPairsComboBox.SelectedValue is DataPair dataPair))
            {
                return;
            }

            this.TemplateDataPairValueTextBox.Text = "";
            this.templateDataXml.Remove(dataPair);

            this.TemplateDataPairsComboBox.ItemsSource = null;
            this.TemplateDataPairsComboBox.ItemsSource = this.templateDataXml.GetAll();
        }

        private void TemplateDataPairsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(this.TemplateDataPairsComboBox.SelectedValue is DataPair dataPair))
            {
                return;
            }

            this.TemplateDataPairValueTextBox.Text = dataPair.Value;
        }

        private void TemplateDataPairValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(this.TemplateDataPairsComboBox.SelectedValue is DataPair dataPair))
            {
                return;
            }

            dataPair.Value = this.TemplateDataPairValueTextBox.Text;
        }

        #endregion

        #region EXAMPLE 3

        private void MixerPerspectiveSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.IsLoaded || !this.connection.IsConnected())
            {
                return;
            }

            var perspective = new MixerPerspective
            {
                TopLeftX = this.MixerPerspectiveTopLeftXSlider.Value,
                TopLeftY = this.MixerPerspectiveTopLeftYSlider.Value,
                TopRightX = this.MixerPerspectiveTopRightXSlider.Value,
                TopRightY = this.MixerPerspectiveTopRightYSlider.Value,
                BottomRightX = this.MixerPerspectiveBottomRightXSlider.Value,
                BottomRightY = this.MixerPerspectiveBottomRightYSlider.Value,
                BottomLeftX = this.MixerPerspectiveBottomLeftXSlider.Value,
                BottomLeftY = this.MixerPerspectiveBottomLeftYSlider.Value
            };

            new MixerPerspectiveSetCommand(this.channel, this.layer, perspective).ExecuteAsync(this.connection).ContinueWith(
                task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        new MixerPerspectiveGetCommand(this.channel, this.layer).ExecuteAsync(this.connection).ContinueWith(
                            task2 =>
                            {
                                if (task2.Status == TaskStatus.RanToCompletion)
                                {
                                    MixerPerspective perspective2 = task2.Result.Perspective;

                                    this.MixerPerspectiveTopLeftXTextBlock.Text =
                                        perspective2.TopLeftX.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveTopLeftYTextBlock.Text =
                                        perspective2.TopLeftY.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveTopRightXTextBlock.Text =
                                        perspective2.TopRightX.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveTopRightYTextBlock.Text =
                                        perspective2.TopRightY.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveBottomRightXTextBlock.Text =
                                        perspective2.BottomRightX.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveBottomRightYTextBlock.Text =
                                        perspective2.BottomRightY.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveBottomLeftXTextBlock.Text =
                                        perspective2.BottomLeftX.GetValueOrDefault().ToString("0.00");
                                    this.MixerPerspectiveBottomLeftYTextBlock.Text =
                                        perspective2.BottomLeftY.GetValueOrDefault().ToString("0.00");
                                }
                            });
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void MixerChromaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.IsLoaded || !this.connection.IsConnected())
            {
                return;
            }

            var chroma = new MixerChroma
            {
                TargetHue = this.MixerChromaTargetHueSlider.Value,
                HueWidth = this.MixerChromaHueWidthSlider.Value,
                MinSaturation = this.MixerChromaMinSaturationSlider.Value,
                MinBrightness = this.MixerChromaMinBrightnessSlider.Value,
                Softness = this.MixerChromaSoftnessSlider.Value,
                SpillSuppress = this.MixerChromaSpillSuppressSlider.Value,
                SpillSuppressSaturation = this.MixerChromaSpillSuppressSaturationSlider.Value,
                ShowMask = this.MixerChromaShowMaskCheckBox.IsChecked
            };

            new MixerChromaSetCommand(this.channel, this.layer, this.MixerChromaEnableCheckBox.IsChecked, chroma)
                .ExecuteAsync(this.connection).ContinueWith(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        new MixerChromaGetCommand(this.channel, this.layer).ExecuteAsync(this.connection).ContinueWith(task2 =>
                        {
                            if (task2.Status == TaskStatus.RanToCompletion)
                            {
                                MixerChroma chroma2 = task2.Result.Chroma;

                                this.MixerChromaTargetHueTextBlock.Text = chroma2.TargetHue.GetValueOrDefault().ToString("000");
                                this.MixerChromaHueWidthTextBlock.Text = chroma2.HueWidth.GetValueOrDefault().ToString("0.00");
                                this.MixerChromaMinSaturationTextBlock.Text =
                                    chroma2.MinSaturation.GetValueOrDefault().ToString("0.00");
                                this.MixerChromaMinBrightnessTextBlock.Text =
                                    chroma2.MinBrightness.GetValueOrDefault().ToString("0.00");
                                this.MixerChromaSoftnessTextBlock.Text = chroma2.Softness.GetValueOrDefault().ToString("0.00");
                                this.MixerChromaSpillSuppressTextBlock.Text =
                                    chroma2.SpillSuppress.GetValueOrDefault().ToString("000");
                                this.MixerChromaSpillSuppressSaturationTextBlock.Text =
                                    chroma2.SpillSuppressSaturation.GetValueOrDefault().ToString("0.00");
                                this.MixerChromaShowMaskCheckBox.IsChecked = chroma2.ShowMask.GetValueOrDefault();
                                this.MixerChromaEnableCheckBox.IsChecked = task2.Result.IsChromaEnabled;
                            }
                        });
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void MixerChromaCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            MixerChromaSlider_ValueChanged(null, null);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.IsLoaded || !this.connection.IsConnected())
            {
                return;
            }

            // Set master volume
            new MixerMasterVolumeSetCommand(this.channel, this.VolumeSlider.Value).ExecuteAsync(this.connection).ContinueWith(
                task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        // Get master volume
                        new MixerMasterVolumeGetCommand(this.channel).ExecuteAsync(this.connection).ContinueWith(tesk2 =>
                        {
                            if (tesk2.Status == TaskStatus.RanToCompletion)
                            {
                                this.VolumePercentageTextBlock.Text = $"{Math.Round(tesk2.Result.MasterVolume / 1 * 100, 0)} %";
                            }
                        });
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion
    }
}