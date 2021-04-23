![example workflow](https://github.com/StilSoft/CasparCG.AmcpClient/actions/workflows/publish.yml/badge.svg)

# CasparCG AmcpClient
CasparCG AmcpClient is .NET library for communication with [CasparCG Server](https://github.com/CasparCG/Server) via [AMCP protocol](https://github.com/CasparCG/help/wiki/AMCP-Protocol).

# Features
* Full Async commands (async/await support for non-blocking UI).
* Executing multiple commands asynchronously (thanks to new CasparCG REQ/RES command).
* Command parameters validation.
* Parsing command response.
* All commands are with proper return data.

# License
CasparCG AmcpClient is distributed under the MIT License, see [LICENSE](LICENSE?raw=true) for details.

# Acknowledgements
Many thanks for [CasparCG Server](https://github.com/CasparCG/Server) project and contributors.

# Important notice
**_Currently support only AMCP 2.1 protocol._**

**_Almost all commands are fully implemented (acording to [AMCP protocol](https://github.com/CasparCG/help/wiki/AMCP-Protocol) specification) but still missing some functions that are not listed in specification._**
