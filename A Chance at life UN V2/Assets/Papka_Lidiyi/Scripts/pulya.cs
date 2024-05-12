using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulya : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10;

    private void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }
    void FixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {

        Damage(collision);
        DestroyFireball();

    }
    private void DestroyFireball() { Destroy(gameObject); }

    private void Damage(Collision collision)
    {
        var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage);
        }
    }
}

