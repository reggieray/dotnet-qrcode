# dotnet-qrcode

.NET tool for creating QR codes.

The tool takes text input to create a QR code.

# Installation

```
dotnet tool install -g dotnet-qrcode
```

# Usage

```
USAGE:
    dotnet-qrcode <text> [OPTIONS]                                                                                                                             
    
EXAMPLES:
    dotnet-qrcode Hello, World!

ARGUMENTS:
    <text>    Text to generate QR code for

OPTIONS:
    -h, --help       Prints help information
    -v, --version    Prints version information
```

# Examples

To create a QR code for 'Hello, World!', type:

```
dotnet-qr "Hello, World!"
```