using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public Transform waypoint;
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
        waypoint.position = GameObject.FindWithTag("Player").transform.position;
    }

    public override void Update()
    {
        if (Time.time - _lastShootTimestamp > shootDelay)
        {
            _lastShootTimestamp = Time.time;
            shooter.Shoot();
        }

        if (Vector3.Distance(transform.position, waypoint.position) > 2.0f)
        {
            Vector3 direction = waypoint.position - transform.position;
            direction.Normalize();

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

            steerable.Thrust(direction.x, direction.y);
        }
        else
        {
            waypoint.position = GameObject.FindWithTag("Player").transform.position;
        }
    }
}
