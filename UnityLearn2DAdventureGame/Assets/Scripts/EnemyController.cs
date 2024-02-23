using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Public variables
    public float enemySpeed; 
    public bool vertical;
    public float changeTime = 3.0f;

    // Private variables
    private Rigidbody2D rigidbody2;
    private float timer;
    private int direction = 1;
    private Animator animator;
    bool aggressive = true;

    private AudioSource _audio;
    public ParticleSystem smokeEffect;
    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!aggressive)
        {
            return;
        } 
    }
    private void FixedUpdate()
    {

        if (!aggressive)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 enemyposition = rigidbody2.position;

        if (vertical)
        {
            enemyposition.y = enemyposition.y + enemySpeed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else 
        {
            enemyposition.x = enemyposition.x + enemySpeed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2.MovePosition(enemyposition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        aggressive = false;
        GetComponent<Rigidbody2D>().simulated = false;
        animator.SetTrigger("Fixed");
        _audio.Stop();
        smokeEffect.Stop();
    }
}
