using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject bullet;

    [SerializeField] private int lifes;

    // Reference to the PointsUI class.
    [SerializeField] private PointsUI pointsUI;

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        Debug.Log("Enemy taking damage!");
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        pointsUI.UpdatePoints(+100);
        Destroy(gameObject);
    }

    float angle = 0;

    // private void FixedUpdate()
    // {
    //     angle += 0.1f;
    //     Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
    //     float x = Mathf.Sin(angle);
    //     float y = Mathf.Cos(angle);

    //     Thrust(x, y);
    // }
}
