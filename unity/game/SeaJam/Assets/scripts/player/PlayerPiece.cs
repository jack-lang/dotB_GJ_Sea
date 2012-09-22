using UnityEngine;
using System.Collections;

public enum Pieces
{
	PIECE_X,
	PIECE_1,
	PIECE_2,
	PIECE_3,
	PIECE_4
}

public class PlayerPiece
{
	public Pieces pieceType ;
	
	public GameObject display ;
	
	public MapNode currentNode ;
	
	// Use this for initialization
	public void Init ( Pieces type, GameObject display )
	{
		pieceType = type ;
		this.display = display ;
	}

	public bool Visisble
	{
		set
		{
			display.SetActiveRecursively ( value ) ;
		}
		
		get
		{
			return display.active ;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

