using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  [SerializeField]GameObject TowerPrefab;
  [SerializeField] bool isplaceable;

  public bool Isplaceable{ get{return isplaceable;}}

void OnMouseDown() 
 {
    if(isplaceable)
    {
    Instantiate(TowerPrefab,transform.position,Quaternion.identity);
    isplaceable =false;
    }
}

}
