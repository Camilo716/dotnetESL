using dotnetESL.Client;

class Program
{
    static void Main(string[] args)
    {
        var client = new Client("mob.bit4bit.in", 60555);

        client.Connect();

        Console.WriteLine(client.Authenticate("<password>"));
    }
}