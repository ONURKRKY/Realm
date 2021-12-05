using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  [SerializeField]Tower TowerPrefab;
  [SerializeField] bool isplaceable;

  public bool Isplaceable{ get{return isplaceable;}}

void OnMouseDown() 
 {
    if(isplaceable)
    {
      bool isplaced= TowerPrefab.CreateTower(TowerPrefab,transform.position);
    
    isplaceable =!isplaced;
    }
}

}
