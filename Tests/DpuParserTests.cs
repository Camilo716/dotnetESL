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
        "Content-Length: 4\n\n";

        int contentLenght = DpuParser.GetContentLenght(dpu);

        Assert.That(contentLenght, Is.EqualTo(contentLenght));
    }
}