using Moq;

namespace OneInc_Server.Tests;

public class StringEncoderManagerTests
{
    private Mock<IStringEncoder> encoderMock;
    private StringEncoderManager manager;

    [SetUp]
    public void SetUp()
    {
        encoderMock = new Mock<IStringEncoder>();
        manager = new StringEncoderManager(encoderMock.Object);
    }

    [Test]
    public async Task StartEncodingStream_EncodesInputAndYieldsCharacters()
    {
        var input = "Hello, World!";
        var cancellationToken = CancellationToken.None;
        var expectedResult = "SGVsbG8sIFdvcmxkIQ==";
        encoderMock.Setup(encoder => encoder.EncodeAsync(input)).ReturnsAsync(expectedResult);

        var actualResult = new List<char>();
        await foreach (var symbol in manager.StartEncodingStream(input, cancellationToken)) actualResult.Add(symbol);

        Assert.That(expectedResult.ToCharArray(), Is.EqualTo(actualResult));
        encoderMock.Verify(encoder => encoder.EncodeAsync(input), Times.Once);
    }

    [Test]
    public void StartEncodingStream_StopsOnCancellationRequest()
    {
        var input = "Test";
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var expectedResult = "Test==";
        encoderMock.Setup(encoder => encoder.EncodeAsync(input)).ReturnsAsync(expectedResult);

        var stream = manager.StartEncodingStream(input, cancellationTokenSource.Token);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (var symbol in stream)
            {
            }
        });
    }
}