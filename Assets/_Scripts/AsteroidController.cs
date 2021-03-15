using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour, IDamageable
{
    private int lifes = 3;
    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
