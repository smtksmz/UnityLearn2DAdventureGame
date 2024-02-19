using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody2D rigidbody2;

    public bool vertical;

    public float changeTime = 3.0f;
    private float timer;
    private int direction = 1;
    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    private void FixedUpdate()
    {
        Vector2 enemyposition = rigidbody2.position;

        if (vertical)
        {
            enemyposition.y = enemyposition.y + enemySpeed * direction * Time.deltaTime;
        }
        else 
        {
            enemyposition.x = enemyposition.x + enemySpeed * direction * Time.deltaTime;
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
}
