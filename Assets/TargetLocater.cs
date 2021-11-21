using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    void Start()
    {
        target=FindObjectOfType<EnemyMover>().transform;
    }

    
    void Update()
    {
        Aimweapon();

    }

    void Aimweapon()
    {
        weapon.LookAt(target);
    }
}
