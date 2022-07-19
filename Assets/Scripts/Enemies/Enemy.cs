using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : CharacterStats
{
    float lastAttack = 0;
    public float attackCooldown = 2;
    public float stoppingDistance;

    NavMeshAgent agent;
    GameController gamecontroller;
    GameObject target;
    Spawner spawner;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        maxHealth = 100;
        currHealth = maxHealth;

        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawner = gamecontroller.GetComponentInChildren<Spawner>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDistance)
        {
            StopEnemy();
            if(Time.time - lastAttack >= attackCooldown)
            {
                lastAttack = Time.time;
                GiveDamage();
            }
        }
        else
        {
            GoToTarget();
        }
        if (currHealth <= 0)
        {
            Die();
        }
    }

    private void GiveDamage()
    {
        target.GetComponent<CharacterStats>().TakeDamage(damage);
    }

    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }

    public override void Die()
    {
        gamecontroller.AddScore(1);
        spawner.enemiesKilled++;
        Destroy(gameObject);
    }
}
