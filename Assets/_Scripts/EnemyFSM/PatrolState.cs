using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    SteerableBehaviour steerable;

    float angle = 0;
    public void Update()
    {
        angle += 0.1f * Time.deltaTime;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(y, y);
    }

    public override void Awake()
    {
        base.Awake();

        Transition ToAttackState = new Transition();
        ToAttackState.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 5.0f);
        ToAttackState.target = GetComponent<AttackState>();
        transitions.Add(ToAttackState);

        steerable = GetComponent<SteerableBehaviour>();
    }
}
