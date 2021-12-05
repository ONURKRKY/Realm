using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentsearchNode;
    Vector2Int[] directions= {Vector2Int.right,Vector2Int.left,Vector2Int.up,Vector2Int.down};
    Gridmanager gridmanager;
    Dictionary<Vector2Int, Node> grid;

    void Awake() 
    {
        gridmanager=FindObjectOfType<Gridmanager>();
        if(gridmanager!=null) 
        {
            grid=gridmanager.Gird;
        }

    }
    void Start()
    {
        ExploreNeigbours();
    }

     void ExploreNeigbours()
    {
        List<Node> Neigbours= new List<Node>();
        foreach( Vector2Int direction in directions)
        {

            Vector2Int NeighbourCoords=currentsearchNode.coordinates+direction;
            if(grid.ContainsKey(NeighbourCoords))
            {
                Neigbours.Add(grid[NeighbourCoords]);
                grid[NeighbourCoords].isExplored=true;
                grid[currentsearchNode.coordinates].isPath=true;
            }
        }
    
    
    }

}
   
