﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIv2 : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PeredvizhenieIgroka player;
    private NavMeshAgent _navMeshAgent;
    public PlayerHealth _playerHealth;
    public Animator _AnimationZombi;

    private bool _isPlayerNoticed;

    public float viewAngle;
    public float timerDlaPublici;
    public float timerPatrylDlaPublici;
    public float damage;

    private float timer;
    private float timerPatryl;
    private bool attaka;

    private void Start()
    {
        InitComponentLinks();
    }
    private void Update()
    {
        NoticePlayerUpdate();
        PatrolUpdate();
        ChaseUpdate();
        AtackUpdate();
        AnimaciaDvizhenia();
        if(attaka == true)
        {
            _AnimationZombi.SetInteger("Attack", 1);
            _AnimationZombi.SetBool("BoolAttack", true);
            _navMeshAgent.speed = 0;
        }
        else
        {
            _AnimationZombi.SetInteger("Attack", 0);
            _AnimationZombi.SetBool("BoolAttack", false);
            _navMeshAgent.speed = 3.5f;
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
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
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
        PatrolUpdate();
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
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
            if (DistanciaIgroka() < 2f)
            {
                timer += Time.deltaTime;
                attaka = true;
                if (timer >= timerDlaPublici)
                {
                    _playerHealth.DealDamage(damage);
                    timer = 0f;
                }
            }
            else
            {
                attaka = false;
                timer = 0;
            }
            float DistanciaIgroka()
            {
                return Vector3.Distance(transform.position, _playerHealth.transform.position);
            }
        }
    }
}
