using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range=15f;
    [SerializeField] ParticleSystem projectileParticleslSystem;
    Transform target;

    void Update()
    {

        FindclosestTarget();
        Aimweapon();

    }

    void FindclosestTarget()

    {
        Enemy[] enemies=FindObjectsOfType<Enemy>();
        Transform colesestTarget=null;
        float maxDistance=Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float TargetDistance= Vector3.Distance(transform.position,enemy.transform.position);
            if(TargetDistance<maxDistance)
            {
                colesestTarget=enemy.transform;
                maxDistance=TargetDistance;
            }
        }
        target=colesestTarget;
    }    
void Aimweapon()
    {
        float targetDistance=Vector3.Distance(transform.position,target.transform.position);
        weapon.LookAt(target);

        if(targetDistance<range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isactive)
    {
        var emmisionModule= projectileParticleslSystem.emission;
        emmisionModule.enabled=isactive;
    }
}
