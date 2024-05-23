using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIv2 : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PeredvizhenieIgroka player;
    public NavMeshAgent _navMeshAgent;
    public PlayerHealth _playerHealth;
    public Animator _AnimationZombi;

    private bool _isPlayerNoticed;
    private bool _Agresivni = false;

    public float attackDistance = 1;

    public float viewAngle;
    public float timerDlaPublici;
    public float timerPatrylDlaPublici;
    public float damage;
    public float spead;
    public bool NugnoPatrylirovanie = false;

    //private float timer;
    private float timerPatryl;
    private float timerAngle;
    public bool attaka;

    private void Start()
    {
        InitComponentLinks();
        FindPlayer();

    }

    private void FindPlayer()
    {
        player = FindObjectOfType<PeredvizhenieIgroka>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void InitEnemyLinks(bool agro)
    {
        _Agresivni = agro;
    }

    private void Update()
    {
        NoticePlayerUpdate();
        if (NugnoPatrylirovanie == true)
        {
            PatrolUpdate();
        }
        ChaseUpdate();
        AtackUpdate();
        AnimaciaDvizhenia();
        AnimaciaAtacki();
        TimerVorAngle();
    }

    private void TimerVorAngle()
    {
        if (viewAngle > 90)
        {
            timerAngle += Time.deltaTime;
            if (timerAngle > 2)
            {
                viewAngle = 90;
                timerAngle = 0;
            }
        }
    }

    private void AnimaciaAtacki()
    {
        if (attaka == true)
        {
            _AnimationZombi.SetInteger("Attack", 1);
            _AnimationZombi.SetBool("BoolAttack", true);
            _navMeshAgent.speed = 0;
        }
        else
        {
            _AnimationZombi.SetInteger("Attack", 0);
            _AnimationZombi.SetBool("BoolAttack", false);
            if (GetComponent<EnemyHealth>().PopaliForAnimation == false)
            _navMeshAgent.speed = spead;
        }
    }

    private void AnimaciaDvizhenia()
    {
        if (_navMeshAgent.velocity.sqrMagnitude >= 0.1)
        {
            _AnimationZombi.SetInteger("Dvizenie", 2);
        }
        else
        {
            _AnimationZombi.SetInteger("Dvizenie", 1);
        }
    }


    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;

        if (!_playerHealth.IsAlive()) return;

        var direction = player.transform.position - transform.position;
        
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
        if (NugnoPatrylirovanie == true)
        {
            PatrolUpdate();
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed || _Agresivni)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            timerPatryl += Time.deltaTime;
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                if (timerPatryl > timerPatrylDlaPublici)
                {
                    PickNewPatrolPoint();
                    timerPatryl = 0f;
                }
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void AtackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= (_navMeshAgent.stoppingDistance + attackDistance))
            {
                attaka = true;
            }

            //if (DistanciaIgroka() < 2f)
            //{
            //    timer += Time.deltaTime;
             //   attaka = true;
           //     if (timer >= timerDlaPublici)
             //   {
              //      _playerHealth.DealDamage(damage);
             //       timer = 0f;
            //    }
           // }
          //  else
           // {
            //    attaka = false;
           //     timer = 0;
           // }
         //   float DistanciaIgroka()
           // {
            //    return Vector3.Distance(transform.position, _playerHealth.transform.position);
          //  }
       // }
        //else
       // {
        //    attaka = false;
         //   timer = 0;
        }
    }
    public void AttackDamage()
    {
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > (_navMeshAgent.stoppingDistance + attackDistance)) return;
            _playerHealth.DealDamage(damage);
    }
}
