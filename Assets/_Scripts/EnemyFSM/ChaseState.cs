﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public Transform[] waypoints;
    SteerableBehaviour steerable;
    IShooter shooter;
    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public override void Awake()
    {
        base.Awake();

        Transition ToPatrolState = new Transition();
        ToPatrolState.condition = new ConditionDistGT(transform, GameObject.FindWithTag("Player").transform, 7.0f);
        ToPatrolState.target = GetComponent<PatrolState>();
        transitions.Add(ToPatrolState);

        steerable = GetComponent<SteerableBehaviour>();

        shooter = steerable as IShooter;
        if (shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }
    }

    public void Start()
    {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
    }

    public override void Update()
    {
        if (Time.time - _lastShootTimestamp > shootDelay)
        {
            _lastShootTimestamp = Time.time;
            shooter.Shoot();
        }

        if (Vector3.Distance(transform.position, waypoints[1].position) > 2.0f)
        {
            Vector3 direction = waypoints[1].position - transform.position;
            direction.Normalize();
            Debug.Log($"Chasing! {direction.x} {direction.y}");
            steerable.Thrust(direction.x, direction.y);
        }
        else
        {
            Debug.Log("Updating position");
            waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
        }
    }
}
