using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class SenderScript : MonoBehaviour {

    UdpClient udpClient;
	void Awake () {
	    udpClient = new UdpClient();
        IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, 51512);
        udpClient.Connect(ep);
    }
	
    public void SendData(byte[] bytes)
    {
        udpClient.Send(bytes, bytes.Length);
    }
}
