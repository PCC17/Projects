using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class ScriptLogic : MonoBehaviour {

	// Use this for initialization
    UdpClient udpClient;
	void Start () {
	    udpClient = new UdpClient();
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.0.0.65"), 51512); // endpoint where server is listening
        udpClient.Connect(ep);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SendData(byte[] bytes)
    {
        udpClient.Send(bytes, bytes.Length);
    }
}
