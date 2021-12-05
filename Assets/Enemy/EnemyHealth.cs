using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints=5;

    [SerializeField] int difficultyRamp=1;
    int currentHitPoints=0;

    Enemy enemy;

 
    // Start is called before the first frame update
    private void OnEnable() {        
    
        currentHitPoints=maxHitPoints;
    }

     void Start()
    {
        enemy=GetComponent<Enemy>();
    }
     void OnParticleCollision(GameObject other) 
    {

        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints<=0)
        {
            enemy.RewardGold();
            maxHitPoints+=difficultyRamp;
            gameObject.SetActive(false);
        }
    }

}
