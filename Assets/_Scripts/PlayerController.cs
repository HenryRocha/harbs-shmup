using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    // Reference to the animator object.
    private Animator animator;

    // Reference to the bullet object.
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform weapon01;

    // Controls the shooting logic.
    [SerializeField] private float shootDelay = 0.5f;
    private float lastShotTs = 0.0f;

    // Number of lifes the player has.
    public int lifes = 10;

    private bool backwards = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        // Get the reference.
        animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (Time.time - lastShotTs > shootDelay) {
            Debug.Log("Shooting bullet!");
            lastShotTs = Time.time;
            GameObject newBullet = Instantiate(bullet, weapon01.position, Quaternion.identity);
            if (backwards) {
                newBullet.GetComponent<ShotBehaviour>().ChangeDir(-1);
            } else {
                newBullet.GetComponent<ShotBehaviour>().ChangeDir(1);
            }
        }
    }

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        if (xInput < 0 && !backwards) {
            backwards = true;
            animator.transform.Rotate(0, 180, 0);
        }

        if (xInput > 0 && backwards) {
            backwards = false;
            animator.transform.Rotate(0, 180, 0);
        }

        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        if(Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
