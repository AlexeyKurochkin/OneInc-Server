namespace OneInc_Server.Tests;

public class StringEncoderTests
{
    [Test]
    public async Task EncodeAsync_Success()
    {
        var input = "Hello, World!";
        var expectedResult = "SGVsbG8sIFdvcmxkIQ==";
        var stringEncoder = new StringEncoder();

        var actualResult = await stringEncoder.EncodeAsync(input);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task EncodeAsync_InvalidInput()
    {
        var stringEncoder = new StringEncoder();

        var testDelegate = async () => await stringEncoder.EncodeAsync(null);

        Assert.That(testDelegate, Throws.Exception.TypeOf<ArgumentNullException>());
    }
}