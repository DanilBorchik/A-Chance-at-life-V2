using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageEvent : MonoBehaviour
{
    public EnemyAIv2 enemyAI;

    public void AttackDamage()
    {
        enemyAI.AttackDamage();
    }
}
