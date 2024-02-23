using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    public ParticleSystem collectibleEffects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1);
            controller.PlaySound(collectedClip);
            Destroy(gameObject);
            collectibleEffects = Instantiate(collectibleEffects,transform.position ,Quaternion.identity);
            collectibleEffects.Play();
        }
    }
}
