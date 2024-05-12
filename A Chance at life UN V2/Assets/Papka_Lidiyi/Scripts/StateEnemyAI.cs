using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateEnemyAI : MonoBehaviour
{
    public pulya pulya;
    public Transform pulyaSourceTransform;

    public List<Transform> patrolPoints;
    public PeredvizhenieIgroka player;
    public float damage = 30;
    public float attackDistance = 1;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    private StateEnemyHealth _stateEnemyHealth;

    private float timer, vremya = 1;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _stateEnemyHealth = GetComponent<StateEnemyHealth>();
        PickNewPatrolPoint();
    }

    public bool IsAlive()
    {
        return _stateEnemyHealth.IsAlive();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        AttackUpdate();
        PatrolUpdate();
        timer += Time.deltaTime;
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= 15)
            {
                if (timer >= vremya)
                {
                    transform.LookAt(player.transform.position);
                    Instantiate(pulya, pulyaSourceTransform.position, pulyaSourceTransform.rotation);
                    timer = 0;
                }
                
            }
        }
    }

    //public void AttackDamage()
   // {
     //   if (!_isPlayerNoticed) return;
      //  if (_navMeshAgent.remainingDistance > attackDistance) return;

      //  _playerHealth.DealDamage(damage);

   // }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;

        if (_playerHealth._OnYmer) return;

        var direction = player.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
            if (hit.collider.gameObject == player.gameObject)
            {
                _isPlayerNoticed = true;
            }
        }
    }

    private void PatrolUpdate()
    {
        if (patrolPoints.Count == 0) return;
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        if (patrolPoints.Count == 0) return;
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

}