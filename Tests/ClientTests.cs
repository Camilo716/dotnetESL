namespace Tests;

public class ClientTests
{
    private const string HOST = "172.16.238.10";
    private const int PORT = 8020;
    private Client _client = null!;

    [SetUp]
    public void SetUp()
    {
        _client = new Client(HOST, PORT);
        _client.Connect();
    }

    [Test]
    public void AuthenticationTest()
    {
        string password = "ClueCon";

        string authResponse = _client.Authenticate(password);

        string succesfullAuthResponse =
        "Content-Type: command/reply\n"+
        "Reply-Text: +OK accepted\n\n";
        Assert.That(authResponse, Is.EqualTo(succesfullAuthResponse));
    }

    [TearDown]
    public void TearDown()
    {
        _client.CloseConnection();
    } 
}
