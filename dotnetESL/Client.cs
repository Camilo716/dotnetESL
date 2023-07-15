using System.Net.Sockets;
using System.Text;
using dotnetESL.Util;

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
        string authRequest = RecolectHeaderResponse(); 

        SendData($"auth {password}");

        string authResponse = RecolectHeaderResponse(); 

        string responseValue = DpuParser.GetLineValueFromKey(authResponse, "Reply-Text");
        return responseValue;
    }

    public int ApiCommand(string args)
    {
        SendData($"api {args}");

        string uptimeHeader = RecolectHeaderResponse();
        string uptimeResponse = RecolectBodyResponse(uptimeHeader);
        
        try
        {
            int intResponse = int.Parse(uptimeResponse);
            return intResponse;
        }
        catch (System.Exception)
        {
            throw new Exception("Did not receive a number");
        }
    }

    private void SendData(string data)
    {
        byte[] msg = Encoding.ASCII.GetBytes($"{data}\n\n");
        _socket.Send(msg);
    }

    private string RecolectBodyResponse(string headerDpu)
    {
        int contentLenght = int.Parse(DpuParser.GetLineValueFromKey(headerDpu, "Content-Length"));
        
        string contentBuffer = "";

        while (contentBuffer.Length < contentLenght)
        {
            contentBuffer += ReceiveData();
        }
        
        return contentBuffer;
    }

    private string RecolectHeaderResponse()
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
