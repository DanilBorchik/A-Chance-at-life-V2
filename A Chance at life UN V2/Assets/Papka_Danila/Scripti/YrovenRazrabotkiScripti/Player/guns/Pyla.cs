using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyla : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 20;
    public float graviti = 5.8f;

    private float _gravi = 0;
    void Start()
    {
        Invoke("DestroyPyly", lifetime);
    }
    void FixedUpdate()
    {
        PeremeshenieEtoiFricadelki();
    }
    private void PeremeshenieEtoiFricadelki()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
        _gravi += graviti * Time.fixedDeltaTime;
        transform.position += Vector3.down * _gravi * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        _Popal(other);
        DestroyPyly();
    }
    private void _Popal(Collider other)
    {
        {
            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
               enemyHealth.DealDamage(damage);
            }
            var stateEnemyHealth = other.gameObject.GetComponent<StateEnemyHealth>();
            if (stateEnemyHealth != null)
            {
                stateEnemyHealth.DealDamage(damage);
            }
        }
    }
    private void DestroyPyly()
    {
        Destroy(gameObject);
    }
}
