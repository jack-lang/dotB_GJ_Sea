using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl {
	
	private NodeMap map ;
	
	private PieceManager pieces ;
	
	public void Init ( NodeMap nodeMap, PieceManager pieceManager, List<GameObject> piecePrefabs )
	{
		map = nodeMap ;
		
		
		pieces = pieceManager ;
		pieces.Init ( piecePrefabs ) ;
		
		MovePieceToNode ( Pieces.PIECE_X, 0 ) ;
	}
	
	
	public void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition ) ;
		
		RaycastHit hit ;
		
		bool collided = Physics.Raycast ( ray, out hit ) ;
		
		if ( collided )
		{
			
			if ( Input.GetMouseButtonDown ( 0 ) )
			{
				if ( hit.rigidbody != null )
				{
					MapNode node = map.NodeForDisplay ( hit.rigidbody.gameObject ) ;
					
					if ( node != null )
					{
						NodeClicked ( node ) ;
					}
				}
			}
		}
	}
	
	public void NodeClicked ( MapNode node )
	{
		NodeConnections connections = map.ConnectionsForNode ( node ) ;
	}
	
	public void MovePieceToNode ( Pieces piece, int node_id )
	{
		PlayerPiece thePiece = pieces.GetPiece ( piece ) ;
		MapNode node = map.NodeForId ( node_id ) ;
		
		MovePieceToNode ( thePiece, node ) ;
	}
	
	public void MovePieceToNode ( PlayerPiece piece, MapNode node )
	{
		piece.display.transform.position = node.display.transform.position ;
		pieces.currentPiece = piece ;
		piece.Visisble = true ;
	}
}
