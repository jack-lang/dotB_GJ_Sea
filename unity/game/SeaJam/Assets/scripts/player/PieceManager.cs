using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceManager : MonoBehaviour
{
	public PlayerPiece currentPiece ;
	public List<NodeMovement> pieceMoves ;
	
	private List<PlayerPiece> pieces ;
	
	public void Init ( List<GameObject> piecePrefabs )
	{
		pieces = new List<PlayerPiece> () ;
		
		for ( int i = 0; i < 5; i++ )
		{
			GameObject display = Instantiate ( piecePrefabs [ i ] ) as GameObject ;
			
			PlayerPiece piece = new PlayerPiece () ;
			piece.Init ( (Pieces)i, display ) ;
			piece.Visisble = false ;
			pieces.Add ( piece ) ;
		}
	}
	
	public PlayerPiece GetPiece ( Pieces piece )
	{
		return GetPiece ( (int)piece ) ;
	}
	
	public PlayerPiece GetPiece ( int index )
	{
		return pieces [ index ] ;
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}

