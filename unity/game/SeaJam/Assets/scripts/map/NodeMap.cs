using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public struct NodeConnections
{
	public MapNode node ;
	public List<MapNode> type1 ;
	public List<MapNode> type2 ;
	public List<MapNode> type3 ;
	public List<MapNode> type4 ;
}

public struct NodeMovement
{
	public MapNode node ;
	public int move ;
}

public class NodeMap {
	
	private Dictionary<MapNode,List<MapNode>> list1 ;
	private Dictionary<MapNode,List<MapNode>> list2 ;
	private Dictionary<MapNode,List<MapNode>> list3 ;
	private Dictionary<MapNode,List<MapNode>> list4 ;
	
	private Dictionary<GameObject,MapNode> displays ;
	
	private List<MapNode> id_list ;
	
	public int nodeCount { get { return id_list.Count ; } }
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void Init ( List<MapNode> nodes )
	{
		list1 = new Dictionary<MapNode, List<MapNode>> () ;
		list2 = new Dictionary<MapNode, List<MapNode>> () ;
		list3 = new Dictionary<MapNode, List<MapNode>> () ;
		list4 = new Dictionary<MapNode, List<MapNode>> () ;
		
		displays = new Dictionary<GameObject, MapNode> () ;
		
		id_list = new List<MapNode> ( nodes.ToArray () ) ; // sort them to avoid relying on execution order
		id_list.Sort ( CompareNodesByX ) ;
		
		for ( int i = 0; i < nodes.Count; i++ )
		{
			CreateMap ( nodes [ i ], nodes [ i ].nodes_1, list1 ) ;
			CreateMap ( nodes [ i ], nodes [ i ].nodes_2, list2 ) ;
			CreateMap ( nodes [ i ], nodes [ i ].nodes_3, list3 ) ;
			CreateMap ( nodes [ i ], nodes [ i ].nodes_4, list4 ) ;
			
			displays [ nodes [ i ].display ] = nodes [ i ] ;
		}
		
		for ( int i = 0; i < nodes.Count; i++ )
		{
			id_list [ i ].ID = i ;
		}
	}
	
	public MapNode NodeForDisplay ( GameObject display )
	{
		if ( displays.ContainsKey ( display ) )
		{
			return displays [ display ] ;
		}
		
		return null ;
	}
	
	public NodeConnections ConnectionsForNode ( MapNode node )
	{
		NodeConnections connections ;
		
		connections.node = node ;
		connections.type1 = list1 [ node ] ;
		connections.type2 = list2 [ node ] ;
		connections.type3 = list3 [ node ] ;
		connections.type4 = list4 [ node ] ;
		
		return connections ;
	}
	
	public MapNode NodeForId ( int id )
	{
		return id_list [ id ] ;
	}
	
	private void CreateMap ( MapNode node, List<GameObject> map, Dictionary<MapNode, List<MapNode>> dict )
	{
		if ( !dict.ContainsKey ( node ) )
			dict [ node ] = new List<MapNode> () ;
		
		for ( int i = 0; i < map.Count; i++ )
		{
			MapNode con_node = map [ i ].GetComponent ( "MapNode" ) as MapNode ;
			
			if ( con_node != null )
			{
				if ( !dict.ContainsKey ( con_node ) )
					dict [ con_node ] = new List<MapNode> () ;
			}
			
			Debug.Log ( string.Format ( "connection, {0}:{1}", node.ID, con_node.ID ) ) ;
			
			if ( !dict [ node ].Contains ( con_node ) )
				dict [ node ] .Add ( con_node ) ;
			
			if ( !dict [ con_node ].Contains ( node ) )
				dict [ con_node ] .Add ( node ) ;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	private static int CompareNodesByX(MapNode x, MapNode y)
    {
        if (x == null)
        {
            if (y == null)
            {
                // If x is null and y is null, they're 
                // equal.  
                return 0;
            }
            else
            {
                // If x is null and y is not null, y 
                // is greater.  
                return -1;
            }
        }
        else
        {
            // If x is not null... 
            // 
            if (y == null)
                // ...and y is null, x is greater.
            {
                return 1;
            }
            else
            {
                // ...and y is not null, compare the  
                // lengths of the two strings. 
                // 
                int retval = x.gameObject.transform.position.x.CompareTo ( y.gameObject.transform.position.x ) ;

                if (retval != 0)
                {
                    // If the strings are not of equal length, 
                    // the longer string is greater. 
                    // 
                    return retval;
                }
                else
                {
                    return x.gameObject.transform.position.y.CompareTo ( y.gameObject.transform.position.y ) ;
                }
            }
        }
    }
}
