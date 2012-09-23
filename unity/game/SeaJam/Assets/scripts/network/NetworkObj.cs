using UnityEngine;
using System.Collections;

public class NetworkObj : MonoBehaviour
{
	public NetworkViewID viewID ;
	
	// Use this for initialization
	void Start ()
	{
		viewID = Network.AllocateViewID () ;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	[RPC]
	void SetPiece ( string msg )
	{
		Debug.Log ( string.Format ( "ahh {0}, {1}", viewID.isMine, msg ) ) ;
	}
	
	[RPC]
	void Win ( bool value )
	{
		if ( Network.isClient )
		{
			Debug.Log ( "WIN" ) ;
		}
	}
}

