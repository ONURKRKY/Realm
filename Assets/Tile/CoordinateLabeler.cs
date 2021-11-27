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
 Waypoint waypoint;


    void Awake() 
    {
    Label=GetComponent<TextMeshPro>();
    Label.enabled=false;
    waypoint=GetComponentInParent<Waypoint>();
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
        if(waypoint.Isplaceable)
        {
            Label.color=Color.blue;
        }
        else
        {
            Label.color=Color.red;
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
