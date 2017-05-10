//////////////////////////////////////////////////////////////////////////////////
//
// Author: Sase
// Email: sase@stilsoft.net
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
//////////////////////////////////////////////////////////////////////////////////


using StilSoft.CasparCG.AmcpClient;
using StilSoft.CasparCG.AmcpClient.Commands.Basic;
using StilSoft.CasparCG.AmcpClient.Commands.Cg;
using StilSoft.CasparCG.AmcpClient.Commands.Cg.Common.TemplateData;
using StilSoft.CasparCG.AmcpClient.Commands.Mixer;
using StilSoft.CasparCG.AmcpClient.Commands.Mixer.Common;
using StilSoft.CasparCG.AmcpClient.Commands.Query;
using StilSoft.CasparCG.AmcpClient.Commands.Query.Common;
using StilSoft.CasparCG.AmcpClient.Commands.Thumbnail;
using StilSoft.Network;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AmcpClientExample
{
    public partial class MainWindow
    {
        private readonly AmcpConnection _connection;
        private readonly Version _minimumServerVersion = new Version("2.1.0.3344");
        private int? _channel;
        private int? _layer;


        public MainWindow()
        {
            InitializeComponent();

            _connection = new AmcpConnection(HostNameTextBox.Text, 5250)
            {
                AutoConnect = true,
                AutoReconnect = true,
                ReconnectAttempts = 5
            };

            _connection.ConnectionStateChanged += (s, e) =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    DisplayConnectionState(e.State);

                    if (e.State == ConnectionState.Connected)
                        LoadServerInfo();
                    else
                        ClearServerInfo();
                }));
            };

            _connection.InternalError += (s, e) => Console.WriteLine(e);
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _connection.ConnectAsync(HostNameTextBox.Text, 5250);
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
                await _connection.DisconnectAsync();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void ChannelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _channel = null;

            int channel;

            if (int.TryParse(ChannelTextBox.Text, out channel))
                _channel = channel;
        }

        private void LayerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _layer = null;

            int layer;

            if (int.TryParse(LayerTextBox.Text, out layer))
                _layer = layer;
        }

        #region EXAMPLE 1

        private async void LoadMediaButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMediaButton.IsEnabled = false;
            MediaListView.ItemsSource = null;

            try
            {
                var response = await new ClsCommand { ResponseTimeout = 10000 }.ExecuteAsync(_connection);

                MediaListView.ItemsSource = response.GetMediaList();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            LoadMediaButton.IsEnabled = true;
        }

        private void ClearListButton_Click(object sender, RoutedEventArgs e)
        {
            MediaListView.ItemsSource = null;
        }

        private async void LoadBgButton_Click(object sender, RoutedEventArgs e)
        {
            var mediaFileInfo = MediaListView.SelectedValue as MediaFileInfo;

            if (mediaFileInfo == null)
                return;

            try
            {
                await new LoadBgCommand(_channel, _layer, mediaFileInfo.FullName).ExecuteAsync(_connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await new PlayCommand(_channel, _layer).ExecuteAsync(_connection);
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
                await new StopCommand(_channel, _layer).ExecuteAsync(_connection);
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
                await new ClearCommand(_channel, _layer).ExecuteAsync(_connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MediaListView_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            // Quick and dirty :)
            var img = ((ListViewItem)sender).ToolTip as Image;

            var mediaFileInfo = ((ListViewItem)e.Source).Content as MediaFileInfo;

            if (mediaFileInfo == null || img == null)
                return;

            img.Source = null;

            if (!_connection.IsConnected())
                return;

            new ThumbnailRetrieveCommand(mediaFileInfo.FullName).ExecuteAsync(_connection).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    img.Source = ToBitmapImage(task.Result.GetThumbnailData());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region EXAMPLE 2 

        private async void LoadTemplatesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadTemplatesButton.IsEnabled = false;
            TemplatesListView.ItemsSource = null;

            try
            {
                var response = await new TlsCommand { ResponseTimeout = 10000 }.ExecuteAsync(_connection);

                TemplatesListView.ItemsSource = response.GetTemplateList();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            LoadTemplatesButton.IsEnabled = true;
        }

        private readonly TemplateDataXml _templateDataXml = new TemplateDataXml();

        private async void TemplatesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _templateDataXml.Clear();
            TemplateDataPairsComboBox.ItemsSource = null;
            TemplateDataPairValueTextBox.Text = "";
            AuthorNameTextBlock.Text = "";
            AuthorEmailTextBlock.Text = "";
            TemplateInfoTextBlock.Text = "";
            VersionTextBlock.Text = "";
            OriginalHeightTextBlock.Text = "";
            OriginalWidthTextBlock.Text = "";


            var templateFileInfo = TemplatesListView.SelectedValue as TemplateFileInfo;

            if (templateFileInfo == null || templateFileInfo.TemplateType != TemplateType.Flash)
                return;

            try
            {
                var response = await new InfoTemplateCommand(templateFileInfo.FullName).ExecuteAsync(_connection);

                AuthorNameTextBlock.Text = response.TemplateInfo.AuthorName;
                AuthorEmailTextBlock.Text = response.TemplateInfo.AuthorEmail;
                TemplateInfoTextBlock.Text = response.TemplateInfo.TemplateInformation;
                VersionTextBlock.Text = response.TemplateInfo.Version;
                OriginalHeightTextBlock.Text = response.TemplateInfo.OriginalHeight.ToString();
                OriginalWidthTextBlock.Text = response.TemplateInfo.OriginalWidth.ToString();

                foreach (var templateInfoInstance in response.TemplateInfo.Instances)
                    _templateDataXml.Add(new DataPair(templateInfoInstance.Name, ""));

                foreach (var templateInfoParameter in response.TemplateInfo.Parameters)
                    _templateDataXml.Add(new DataPair(templateInfoParameter.Id, ""));

                TemplateDataPairsComboBox.ItemsSource = _templateDataXml.GetAll();

                if (TemplateDataPairsComboBox.Items.Count > 0)
                    TemplateDataPairsComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private async void LoadAndPlayTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            var templateFileInfo = TemplatesListView.SelectedValue as TemplateFileInfo;

            if (templateFileInfo == null)
                return;

            try
            {
                await new CgAddCommand(_channel, _layer, 0, templateFileInfo.FullName, true, _templateDataXml).ExecuteAsync(_connection);
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
                await new CgStopCommand(_channel, _layer, 0).ExecuteAsync(_connection);
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
                await new CgUpdateCommand(_channel, _layer, 0, _templateDataXml).ExecuteAsync(_connection);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void AddTemplateDataPairButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TemplateDataPairNameTextBox.Text))
                return;

            try
            {
                _templateDataXml.Add(new DataPair(TemplateDataPairNameTextBox.Text, ""));
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            TemplateDataPairsComboBox.ItemsSource = null;
            TemplateDataPairsComboBox.ItemsSource = _templateDataXml.GetAll();

            TemplateDataPairsComboBox.SelectedIndex = TemplateDataPairsComboBox.Items.Count - 1;
            TemplateDataPairNameTextBox.Text = "";
        }

        private void RemoveTemplateDataPairButton_Click(object sender, RoutedEventArgs e)
        {
            var dataPair = TemplateDataPairsComboBox.SelectedValue as DataPair;

            if (dataPair == null)
                return;

            TemplateDataPairValueTextBox.Text = "";
            _templateDataXml.Remove(dataPair);

            TemplateDataPairsComboBox.ItemsSource = null;
            TemplateDataPairsComboBox.ItemsSource = _templateDataXml.GetAll();
        }

        private void TemplateDataPairsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataPair = TemplateDataPairsComboBox.SelectedValue as DataPair;

            if (dataPair == null)
                return;

            TemplateDataPairValueTextBox.Text = dataPair.Value;
        }

        private void TemplateDataPairValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var dataPair = TemplateDataPairsComboBox.SelectedValue as DataPair;

            if (dataPair == null)
                return;

            dataPair.Value = TemplateDataPairValueTextBox.Text;
        }

        #endregion

        #region EXAMPLE 3

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded || !_connection.IsConnected())
                return;

            // Set master volume
            new MixerMasterVolumeSetCommand(_channel, VolumeSlider.Value).ExecuteAsync(_connection).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    // Get master volume
                    new MixerMasterVolumeGetCommand(_channel).ExecuteAsync(_connection).ContinueWith(tesk2 =>
                    {
                        if (tesk2.Status == TaskStatus.RanToCompletion)
                            VolumePercentageTextBlock.Text = $"{Math.Round(tesk2.Result.MasterVolume / 1 * 100, 0)} %";
                    });
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void MixerPerspectiveSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded || !_connection.IsConnected())
                return;

            var perspective = new MixerPerspective
            {
                TopLeftX = MixerPerspectiveTopLeftXSlider.Value,
                TopLeftY = MixerPerspectiveTopLeftYSlider.Value,
                TopRightX = MixerPerspectiveTopRightXSlider.Value,
                TopRightY = MixerPerspectiveTopRightYSlider.Value,
                BottomRightX = MixerPerspectiveBottomRightXSlider.Value,
                BottomRightY = MixerPerspectiveBottomRightYSlider.Value,
                BottomLeftX = MixerPerspectiveBottomLeftXSlider.Value,
                BottomLeftY = MixerPerspectiveBottomLeftYSlider.Value
            };

            new MixerPerspectiveSetCommand(_channel, _layer, perspective).ExecuteAsync(_connection).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    new MixerPerspectiveGetCommand(_channel, _layer).ExecuteAsync(_connection).ContinueWith(task2 =>
                    {
                        if (task2.Status == TaskStatus.RanToCompletion)
                        {
                            var perspective2 = task2.Result.Perspective;

                            MixerPerspectiveTopLeftXTextBlock.Text = perspective2.TopLeftX.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveTopLeftYTextBlock.Text = perspective2.TopLeftY.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveTopRightXTextBlock.Text = perspective2.TopRightX.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveTopRightYTextBlock.Text = perspective2.TopRightY.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveBottomRightXTextBlock.Text = perspective2.BottomRightX.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveBottomRightYTextBlock.Text = perspective2.BottomRightY.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveBottomLeftXTextBlock.Text = perspective2.BottomLeftX.GetValueOrDefault().ToString("0.00");
                            MixerPerspectiveBottomLeftYTextBlock.Text = perspective2.BottomLeftY.GetValueOrDefault().ToString("0.00");
                        }
                    });
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region EXAMPLE 4

        private async void LoadThumbnailsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var totalThumbnails = int.Parse(LoadTotalThumbnailsTextBox.Text);

                LoadThumbnailsButton.IsEnabled = false;
                ThumbnailsListView.ItemsSource = null;

                var thumbnailList = new ObservableCollection<ImageSource>();

                ThumbnailsListView.ItemsSource = thumbnailList;

                var response = await new ThumbnailListCommand { ResponseTimeout = 10000 }.ExecuteAsync(_connection);

                foreach (var thumbnailFileInfo in response.GetThumbnailList())
                {
                    var response2 = await new ThumbnailRetrieveCommand(thumbnailFileInfo.FullName).ExecuteAsync(_connection);

                    thumbnailList.Add(ToBitmapImage(response2.GetThumbnailData()));

                    if (--totalThumbnails == 0)
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            LoadThumbnailsButton.IsEnabled = true;
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
            var color = Brushes.Red;

            switch (e)
            {
                case ConnectionState.Connecting:
                    color = Brushes.Yellow;
                    break;
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

            ConnectionStateIndicator.Fill = color;
            ConnectionStateTextBlock.Text = e.ToString();
        }

        private async void LoadServerInfo()
        {
            try
            {
                var version = await _connection.GetServerVersionAsync();

                ServerVersionTextBlock.Text = version.ToString();

                if (version < _minimumServerVersion)
                    ShowMessage($"CasparCG server version {version} currently is not fully supported. " +
                                $"Minimum supported version is {_minimumServerVersion} or newer.", MessageBoxImage.Warning);
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        private void ClearServerInfo()
        {
            ServerVersionTextBlock.Text = "";
        }

        private void ShowMessage(string message, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(message, "Amcp Client Example", MessageBoxButton.OK, messageBoxImage);
        }

        private void ShowException(Exception exception)
        {
            var includeExceptionType = false;
            var includeStackTrace = false;
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
                    exceptionString.AppendLine();

                exception = exception.InnerException;
            }

            return exceptionString.ToString();
        }
    }
}
