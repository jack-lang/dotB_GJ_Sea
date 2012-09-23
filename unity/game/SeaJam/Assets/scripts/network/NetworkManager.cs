using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public void Init ( bool server )
	{
		if ( server )
		{
			Network.InitializeServer ( 1, 2000, false ) ;
		}
		else
		{
			Network.Connect ( "j3.local", 2000 ) ;
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// server
	void OnServerInitialized() 
	{
	    Debug.Log ( "Server initialized and ready" ) ;
	}
	
	private int playerCount = 0;
	
    void OnPlayerConnected(NetworkPlayer player) {
        Debug.Log("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
    }
	
	// client
	
	void OnConnectedToServer() {
        Debug.Log("Connected to server");
    }
}
