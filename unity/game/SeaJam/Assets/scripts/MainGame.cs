using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {
	
	public static List<MapNode> nodeList = new List<MapNode> ();
	
	PieceManager pieceManager ;
	public List<GameObject> piecePrefabs ;
	
	private NodeMap map ;
	
	private GameControl control ;
	
	// Use this for initialization
	void Start () 
	{
		Network.InitializeServer ( 1, 2000, false ) ;
		
		pieceManager = gameObject.AddComponent ( "PieceManager" ) as PieceManager ;
		
		map = new NodeMap () ;
		map.Init ( nodeList ) ;
		
		control = new GameControl () ;
		control.Init ( map, pieceManager, piecePrefabs ) ;
		
		Debug.Log ( nodeList.Count ) ;
	}
	
	// Update is called once per frame
	void Update () {
		control.Update () ;
	}
}
