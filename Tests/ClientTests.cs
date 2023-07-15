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
    public void SuccesfullAuthenticationTest()
    {
        string password = "ClueCon";

        string authResponse = _client.Authenticate(password);

        string succesfullAuthResponse =
        "Content-Type: command/reply\n"+
        "Reply-Text: +OK accepted\n\n";
        Assert.That(authResponse, Is.EqualTo(succesfullAuthResponse));
    }

    [Test]
    public void FailedAuthenticationTest()
    {
        string password = "ClueCon";

        string authResponse = _client.Authenticate(password);

        Assert.That(authResponse, Is.EqualTo("-ERR invalid"));
    }

    [Test]
    public void ApiUptimeTest()
    {
        _client.Authenticate("ClueCon");

        int uptimeResponse = _client.Uptime();

        bool timeIsRunningAndResponseIsANumber = uptimeResponse > 0;
        Assert.True(timeIsRunningAndResponseIsANumber);
    }

    [TearDown]
    public void TearDown()
    {
        _client.CloseConnection();
    } 
}
