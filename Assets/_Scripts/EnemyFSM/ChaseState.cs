using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public Transform[] waypoints;
    SteerableBehaviour steerable;

    public override void Awake()
    {
        base.Awake();

        // Transition ToAttackState = new Transition();
        // ToAttackState.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 5.0f);
        // ToAttackState.target = GetComponent<AttackState>();
        // transitions.Add(ToAttackState);

        steerable = GetComponent<SteerableBehaviour>();
    }

    public void Start()
    {
        waypoints[0].position = transform.position;
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
    }

    public override void Update()
    {
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
