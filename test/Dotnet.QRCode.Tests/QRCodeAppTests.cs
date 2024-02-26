using FluentAssertions;
using Spectre.Console.Testing;

namespace Dotnet.QRCode.Tests
{
    public class QRCodeAppTests
    {
        [Theory]
        [MemberData(nameof(SingleAndMultipleArgumentsTestData))]
        public async void Should_Handle_SingleAndMultipleArguments(string[] args)
        {
            //Given
            var app = new CommandAppTester();
            app.SetDefaultCommand<QRCodeCommand>();

            // When
            var result = await app.RunAsync(args);

            // Then
            result.ExitCode.Should().Be(0);
            result.Settings.Should().BeOfType<QRCodeCommandSettings>()
                .Which.Text.Should().BeEquivalentTo(args);
        }

        public static IEnumerable<object[]> SingleAndMultipleArgumentsTestData =>
        new List<object[]>
        {
            new object[] { new string[] { "Hello, World!" } },
            new object[] { new string[] { "Hello,", "World!" } },
            new object[] { new string[] { "Hello", ",", "World!" } },
            new object[] { new string[] { "Hello", ",", "World", "!" } }
        };
    }
}