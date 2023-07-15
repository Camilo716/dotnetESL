using dotnetESL.Client;

class Program
{
    static void Main(string[] args)
    {
        var client = new Client("172.16.238.10", 8020);

        client.Connect();

        Console.WriteLine(client.Authenticate("sds"));

        Console.WriteLine(client.Uptime());
    }
}