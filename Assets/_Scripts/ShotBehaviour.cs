using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{
    private float dir;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {   
        Debug.Log(dir);
        Thrust(dir, 0);
    }

    public void ChangeDir(float speed) {
        dir = speed;
        Debug.Log($"Change dir {dir}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Bullet"))
        {
            IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
            if (!(damageable is null))
            {
                damageable.TakeDamage();
            }
        }

        Debug.Log("Destroying bullet!");
        Destroy(gameObject);
    }
}
