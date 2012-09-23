using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	NetworkView view = new NetworkView () ;
	
	NetworkObj obj ;
	
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
	
	void OnDestroy() {
        if ( Network.isClient )
		{
			Network.Disconnect () ;
		}
    }
	
	// server
	
	NetworkPlayer thePlayer ;
	
	void OnServerInitialized() 
	{
	    Debug.Log ( "Server initialized and ready" ) ;
		
		obj = gameObject.AddComponent ( "NetworkObj" ) as NetworkObj ;
	}
	
	void OnPlayerConnected(NetworkPlayer player) {
        Debug.Log("Player " + player.guid + " connected from " + player.ipAddress + ":" + player.port);
		
		thePlayer = player ;
    }
	
	void OnPlayerDisconnected(NetworkPlayer player) {
		if ( thePlayer == player )
		{
	        Debug.Log("Clean up after player " + player);
	        Network.RemoveRPCs(player);
	        Network.DestroyPlayerObjects(player);
		}
    }
	
	public void SetupGame ()
	{
		//
	}
	
	// client
	
	void OnConnectedToServer() {
        Debug.Log("Connected to server");
		obj = gameObject.AddComponent ( "NetworkObj" ) as NetworkObj ;
    }
}
