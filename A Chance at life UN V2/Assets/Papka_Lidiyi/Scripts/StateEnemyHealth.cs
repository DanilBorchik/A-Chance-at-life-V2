using System;
using UnityEngine;
using UnityEngine.AI;

public class StateEnemyHealth : MonoBehaviour
{
    public float value = 100;
    public bool IsAlive(){return value > 0;}
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        //GetComponent<StateEnemyAI>().enabled = false;
        //GetComponent<NavMeshAgent>().enabled = false;
    }
}
