using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class MapNode : MonoBehaviour {
	
	public static int id_count = 0 ;
	
	private int _id ;
	
	public GameObject particlePrefab ;
	
	public List<GameObject> nodes_1 ;
	public List<GameObject> nodes_2 ;
	public List<GameObject> nodes_3 ;
	public List<GameObject> nodes_4 ;
	
	private GameObject particlesObject ;
	public GameObject display ;
	
	void Awake ()
	{
		_id = id_count++ ;
		
		MainGame.nodeList.Add ( this ) ;
	}
	
	public int ID
	{
		get { return _id ; }
		set { _id = value ; }
	}
	
	// Use this for initialization
	void Start () {
		
		particlesObject = Instantiate ( particlePrefab ) as GameObject ;
		particlesObject.transform.position = transform.position ;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ShowParticles ( bool value )
	{
		particlesObject.SetActiveRecursively ( value ) ;
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.DrawIcon ( gameObject.transform.position, "Light Gizmo.tiff" ) ;
		
		if ( nodes_1 != null )
		{
			Gizmos.color = Color.yellow ;
			DrawNodeGizmos ( nodes_1 ) ;
		}
		
		if ( nodes_2 != null )
		{
			Gizmos.color = Color.green ;
			DrawNodeGizmos ( nodes_2 ) ;
		}
		
		if ( nodes_3 != null )
		{
			Gizmos.color = Color.red ;
			DrawNodeGizmos ( nodes_3 ) ;
		}
		
		if ( nodes_4 != null )
		{
			Gizmos.color = Color.blue ;
			DrawNodeGizmos ( nodes_4 ) ;
		}
	}
	
	void DrawNodeGizmos ( List<GameObject> list )
	{
		for ( int i = 0; i < list.Count; i++ )
		{
			if ( list [ i ] != null )
			{
				Vector3 dest = list [ i ].transform.position ;
				Gizmos.DrawLine ( gameObject.transform.position, dest ) ;
			}
		}
	}
}
