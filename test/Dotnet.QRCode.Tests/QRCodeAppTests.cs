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
            //Arrange
            var app = new CommandAppTester();
            app.SetDefaultCommand<QRCodeCommand>();

            //Act
            var result = await app.RunAsync(args);

            //Assert
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