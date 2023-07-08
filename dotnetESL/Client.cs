using System.Net.Sockets;
using System.Text;

namespace dotnetESL.Client;

public class Client
{
    private Socket _socket;
    private string HOST;
    private int PORT;

    public Client(string host, int port)
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        HOST = host;
        PORT = port;
    }

    public void Connect()
    {
        _socket.Connect(HOST, PORT);
    }

    public void CloseConnection()
    {
        _socket.Close();
    }

    public string Authenticate(string password)
    {
        string authRequest = RecolectData(); 

        SendData($"auth {password}");

        string authResponse = RecolectData(); 

        return authResponse;
    }

    public string Uptime()
    {
        SendData("api uptime");

        string uptimeResponse = RecolectData();

        return uptimeResponse;
    }

    private void SendData(string data)
    {
        byte[] msg = Encoding.ASCII.GetBytes($"{data}\n\n");
        _socket.Send(msg);
    }

    private string RecolectData()
    {
        string dataBuffer = "";

        while (!dataBuffer.EndsWith("\n\n"))
        {
            dataBuffer += ReceiveData();
        }

        return dataBuffer;
    }

    private string ReceiveData()
    {
        byte[] buffer = new byte[10000];
        int bytesReceived = _socket.Receive(buffer);
        
        string data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

        return data;
    }

}
