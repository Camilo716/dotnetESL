# dotnetESL
FreeSWITCH Event Socket Library

see https://developer.signalwire.com/freeswitch/FreeSWITCH-Explained/Modules/mod_event_socket_1048924/
### Mode of operation:
`outbound`


### Requirements:
- FreeSWITCH server to connect. For local development can use https://github.com/Camilo716/FreeSWITCH
- .NET 6

### Usage

````
string ip = "0.0.0.0";
int port = 0000
var client = new Client(ip, port);

client.Connect()

string password = "ClueCon"
client.Authenticate(password)

// Use api commands, ex:
client.ApiCommand("uptime");
client.ApiCommand("originate user/1002 &echo()")

client.CloseConnection();
````
