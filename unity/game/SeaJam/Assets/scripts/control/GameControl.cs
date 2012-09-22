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
		HighlightAvailableNodes () ;
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
		//
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
		piece.currentNode = node ;
		pieces.currentPiece = piece ;
		piece.Visisble = true ;
	}
	
	public void HighlightAvailableNodes ()
	{
		NodeConnections connections = map.ConnectionsForNode ( pieces.currentPiece.currentNode ) ;
		List<NodeMovement> moves = pieces.pieceMoves = new List<NodeMovement> () ;
		List<int> move_ids = new List<int> () ;
		
		AddMoves ( connections.type1, 0, moves, move_ids ) ;
		AddMoves ( connections.type2, 1, moves, move_ids ) ;
		AddMoves ( connections.type3, 2, moves, move_ids ) ;
		AddMoves ( connections.type4, 3, moves, move_ids ) ;
		
		for ( int i = 0; i < map.nodeCount; i++ )
		{
			MapNode node = map.NodeForId ( i ) ;
			node.ShowParticles ( move_ids.IndexOf ( node.ID ) >= 0 ) ;
		}
	}
					
	private void AddMoves ( List<MapNode> nodes, int moveType, List<NodeMovement> outList, List<int> idList )
	{
		for ( int i = 0; i < nodes.Count; i++ )
		{
			Debug.Log ( string.Format ( "node move {0} {1}", i, nodes [ i ].ID ) ) ;
			NodeMovement move ;
			move.node = nodes [ i ] ;
			move.move = moveType ;
			
			outList.Add ( move ) ;
			idList.Add ( move.node.ID ) ;
		}
	}
	
}
