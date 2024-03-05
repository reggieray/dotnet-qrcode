$package = 'dotnet-qrcode'
$csproj = "src/Regis.Dotnet.QRCode/Regis.Dotnet.QRCode.csproj"

dotnet tool uninstall -g $package

dotnet pack $csproj --output ./nupkg

$version = ([Xml] (Get-Content $csproj)).Project.PropertyGroup.Version

dotnet tool install -g $package --add-source 'nupkg/' --version $version