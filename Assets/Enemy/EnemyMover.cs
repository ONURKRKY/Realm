using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]List<Waypoint> path= new List<Waypoint>();
    [SerializeField] float speed=1f;

    Enemy enemy;
  


    // Start is called before the first frame update
     void OnEnable() {       
    
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());       
        
    }
    void Start() 
    {
    enemy=GetComponent<Enemy>();    
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FindPath()
    {
        path.Clear();

        GameObject [] waypoints=GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
           path.Add(waypoint.GetComponent<Waypoint>());
        }

    }

    void ReturnToStart()
    {
       transform.position=path[0].transform.position;
    }
    IEnumerator FollowPath()
    {
        
        foreach(Waypoint waypoint in path)
        {
        Vector3 startPosition=transform.position;
        Vector3 endPosition=waypoint.transform.position;
        float travelPercentage=0f;
        transform.LookAt(endPosition);

        while(travelPercentage<1)
        {
            travelPercentage+=Time.deltaTime*speed;
            transform.position=Vector3.Lerp(startPosition,endPosition,travelPercentage);
            yield return new WaitForEndOfFrame();

        }
        
        }
        enemy.StealGold();
        gameObject.SetActive(false);
    }

}
