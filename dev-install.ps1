$package = 'dotnet-qrcode'
$csproj = "src/Dotnet.QRCode/dotnet-qrcode.csproj"

dotnet tool uninstall -g $package

dotnet pack $csproj --output ./nupkg

$version = ([Xml] (Get-Content $csproj)).Project.PropertyGroup.Version

dotnet tool install -g $package --add-source 'nupkg/' --version $version