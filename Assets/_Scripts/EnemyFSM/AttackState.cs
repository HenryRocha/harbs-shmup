using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    SteerableBehaviour steerable;
    IShooter shooter;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public override void Awake()
    {
        base.Awake();


        Transition ToPatrolState = new Transition();
        ToPatrolState.condition = new ConditionDistGT(transform,
            GameObject.FindWithTag("Player").transform,
            5.0f);
        ToPatrolState.target = GetComponent<PatrolState>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToPatrolState);

        steerable = GetComponent<SteerableBehaviour>(); // acho que caguei kkkkk
        shooter = steerable as IShooter;
        if (shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }

    }

    public override void Update()
    {

        //TODO: Movimentação quando atacando

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
