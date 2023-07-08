namespace Tests;

public class ClientTests
{
    private const string HOST = "172.16.238.10";
    private const int PORT = 8020;
    private Client _client;

    [SetUp]
    public void SetUp()
    {
        _client = new Client(HOST, PORT);
    }

    [Test]
    public void AuthenticationTest()
    {
        _client.Connect();
        
        string authResponse = _client.Authenticate(password:"ClueCon");

        string succesfullAuthResponse =
        "Content-Type: command/reply\n"+
        "Reply-Text: +OK accepted\n\n";
        Assert.That(authResponse, Is.EqualTo(succesfullAuthResponse));
    }
}
