using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float _speed;
    public int damage = 25;

    void Start()
    {
        MoveFixedUpdate();
        Destroy(gameObject, 10f);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }


    void FixedUpdate()
    {
        
        
    }

    private void MoveFixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }
    private void OnCollisionEnter(Collision collision)
    {

        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
            Destroy(gameObject);
        }


        
    }


}
