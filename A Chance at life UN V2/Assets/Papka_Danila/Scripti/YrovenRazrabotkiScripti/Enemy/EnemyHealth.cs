using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _hp = 100;
    public Animator _animatorKontroler;
    public bool PopaliForAnimation;

    private void Update()
    {
        if(PopaliForAnimation == true)
        {
            Invoke("PopalAnimation", 1f);
            GetComponent<EnemyAIv2>()._navMeshAgent.speed = 0;
        }
        else
        {
            if (GetComponent<EnemyAIv2>().attaka == false)
            {
                GetComponent<EnemyAIv2>()._navMeshAgent.speed = GetComponent<EnemyAIv2>().spead;
            }
        }
    }

    private void PopalAnimation()
    {
        _animatorKontroler.SetBool("Popal", false);
        PopaliForAnimation = false;
    }

    public void DealDamage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
        GetComponent<EnemyAIv2>().viewAngle = 360;
        _animatorKontroler.SetBool("Popal", true);
        PopaliForAnimation = true;
    }
}
