using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public int damage = 25;
    void Start()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    void FixedUpdate()
    {

        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {

        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);

        }


        Destroy(gameObject);
    }


}
