using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    SteerableBehaviour steerable;

    float angle = 0;
    public void FixedUpdate()
    {
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(x, y);
    }

    public override void Awake()
    {
        base.Awake();

        Transition ToChaseState = new Transition();
        ToChaseState.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 7.0f);
        ToChaseState.target = GetComponent<ChaseState>();
        transitions.Add(ToChaseState);

        steerable = GetComponent<SteerableBehaviour>();
    }
}
