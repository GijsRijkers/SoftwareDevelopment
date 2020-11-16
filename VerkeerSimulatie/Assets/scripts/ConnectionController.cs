using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;  
using System.Net.Sockets;  
using System.Text;
using System.IO;
using System.Threading;
using Newtonsoft.Json;


public class ConnectionController : MonoBehaviour
{

    public StoplichtController stoplichtController;
    

    private Socket socket;
    public InputField port;
    public Button button;
    byte[] buffer;
	private IPAddress localAddr;

	private Thread clientReceiveThread;
	private Thread clientSendThread; 

    // Start is called before the first frame update
    void Start()
    {
        buffer = new byte[1024];
		localAddr = IPAddress.Parse("127.0.0.1");
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);						

    }

    public void ButtonPressed(){
        Connect();
    }


    public void Connect(){       
        try{
            clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();
            Debug.Log("Recieve thread gestart");
			//clientSendThread = new Thread(new ThreadStart(TestMessage)); 
			//clientSendThread.IsBackground = true;
			//clientSendThread.Start();
            }

        catch(Exception e){ 
            Debug.Log("On client connect exception " + e); 		
        }
    }

    private void ListenForData() { 		
		try { 			
			IPEndPoint localEndpoint = new IPEndPoint(localAddr, Int32.Parse(port.text));

            while (!socket.Connected)
            {
                try
                {
                    socket.Connect(localEndpoint);
                }
                catch (SocketException e)
                {
                    Debug.Log("Unable to connect to server.");
                }
            }

            while (socket.Connected)
            {
				StartListening();
            }        
		}         
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}  	

    public void TestMessage() { 
		while (!socket.Connected){
			Debug.Log("Socket aan het verbinden");
		}
		while (socket.Connected){
		Debug.Log("Verstuurd denk ik");   
		string package = "Hallo!}";   
		byte[] dataBytes = Encoding.Default.GetBytes(package);
        socket.Send(dataBytes);
        Thread.Sleep(1000);
		}
	}   

	public void StartListening()
        {
            while (socket.Available > 0)
            {
                int receivedDataLength = socket.Receive(buffer);

                string stringData = Encoding.ASCII.GetString(buffer, 0, receivedDataLength);
                if (!string.IsNullOrEmpty(stringData)){
                    while(stringData.Substring(0,1) != "{"){
                        stringData = stringData.Remove(0,1);
                    }
                    dynamic json  = JsonConvert.DeserializeObject(stringData);
                    stoplichtController.setJson(json);


                }
				
            }
        }
}
