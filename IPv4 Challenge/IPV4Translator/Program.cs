
using IPV4Translator;

string IPv4 = "123.123.123.123/23";
LeoIPAddress test = new LeoIPAddress(IPv4);
Console.WriteLine($"{IPv4}\n{test.Address()}\n{test.SubnetMask()}\n{test.NetworkID()}\n{test.Broadcast()}\n{test.Range()}");

/*
 C# Subnet Calculator
given a tcpip address in the following format:
123.123.123.123/23 // HAS SUBNET as string
 

Task 1:
Parse the following:
Subnet address:
11111111.11111111.11111110.00000000
Network ID:
123.123.122.0
Network range:
123.123.122.0 - 123.123.123.255


Task 2:
given a tcpip address in the following format:
123.123.123.123/23
determine if another IP address is in the same network.

bool IsSameNetwork(IPAddress)

Class IPAddress
byte[4] address
byte[4] subnetmask
byte[4] broadcast
byte[4] networkid
ctor 123.123.123.123/23
bool IsSameNetwork(IPAddress)
ToString=>123.123.123.123/23
 */
