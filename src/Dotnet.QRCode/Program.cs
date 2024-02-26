using Dotnet.QRCode;
using Spectre.Console;
using Spectre.Console.Cli;

public class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandApp<QRCodeCommand>();
        app.Configure(config =>
        {
            config.SetApplicationName("dotnet-qrcode");

            config.AddExample("Hello, World!");

#if DEBUG
            config.PropagateExceptions();
            config.ValidateExamples();
#endif
        });

        try
        {
            return app.Run(args);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -1;
        }
    }
}