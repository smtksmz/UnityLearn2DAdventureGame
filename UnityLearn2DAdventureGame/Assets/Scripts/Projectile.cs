using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.magnitude > 50.0f)
        {
            Destroy(gameObject);
        }
    }


    public void launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemy = collision.collider.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }

        Destroy(gameObject);
    }
}

