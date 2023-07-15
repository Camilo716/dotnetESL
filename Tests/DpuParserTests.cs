namespace Tests;

public class DpuParserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetContentLenghtTest()
    {
        string dpu =
        "Content-Type: api/response\n" +
        "Content-Length: 43\n\n";
        string key = "Content-Length";

        string contentLenght = DpuParser.GetLineValueFromKey(dpu, key);

        Assert.That(contentLenght, Is.EqualTo("43"));
    }

    [Test]
    public void GetReplyTextTest()
    {
        string dpu =
        "Content-Type: command/reply\n"+
        "Reply-Text: -ERR invalid\n\n";
        string key = "Reply-Text";

        string replyText = DpuParser.GetLineValueFromKey(dpu, key);
        Assert.That(replyText, Is.EqualTo("-ERR invalid"));
    }
}