using dotnetESL.Client;

class Program
{
    static void Main(string[] args)
    {
        var client = new Client("172.16.238.10", 8020);

        client.Connect();

        Console.WriteLine(client.Authenticate("ClueCon"));

        Console.WriteLine(client.Uptime());

        string packageDataUnit = "Content-Type: api/response\nContent-Length: 5123\n\n";

        var lines = packageDataUnit.Split();
        

        
        System.Console.WriteLine();
    }
}