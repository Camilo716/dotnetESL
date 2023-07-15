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
}