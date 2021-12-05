using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
 

 TextMeshPro Label;
 Vector2Int coordinates= new Vector2Int();
 Gridmanager gridmanager;



    void Awake() 
    {
    gridmanager=FindObjectOfType<Gridmanager>();
    Label=GetComponent<TextMeshPro>();
    Label.enabled=false;
  
    DisplayCoordinates();

    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinates();
        ToogleLabels();
        
    }
        void ToogleLabels()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                Label.enabled=!Label.IsActive();
                
            }
        }
    void ColorCoordinates()
    {
        if(gridmanager== null){return;}

        Node node=gridmanager.GetNode(coordinates);

        if(node==null) return;
        if(!node.isWalkable)
        {
            Label.color=Color.red;
        }
        else if(node.isPath)
        {
            Label.color=Color.white;
        }
          else if(node.isExplored)
        {
            Label.color=Color.blue;
        }
        else
        {
            Label.color=Color.green;
        }
    }
     void DisplayCoordinates()
    {
        coordinates.x=Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y=Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
        Label.text=coordinates.x +","+coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name=coordinates.ToString();
    }
}
