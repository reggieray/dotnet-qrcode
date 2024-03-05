using Net.Codecrete.QrCodeGenerator;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace Dotnet.QRCode
{
    public class QRCodeCommandSettings : CommandSettings
    {
        [Description("Text to generate QR code for")]
        [CommandArgument(0, "<text>")]
        public required string[] Text { get; init; }
    }

    public class QRCodeCommand : Command<QRCodeCommandSettings>
    {
        public override int Execute(CommandContext context, QRCodeCommandSettings settings)
        {
            var qr = QrCode.EncodeText(string.Join(" ", settings.Text), QrCode.Ecc.Medium);
            var image = new CanvasImage(qr.ToBmpBitmap(1));
            AnsiConsole.Write(image);

            return 0;
        }
    }
}
