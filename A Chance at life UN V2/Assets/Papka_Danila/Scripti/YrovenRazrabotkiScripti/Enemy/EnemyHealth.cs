using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _hp = 100;
    
    public void DealDamage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
        GetComponent<EnemyAIv2>().viewAngle = 360;
    }
}
