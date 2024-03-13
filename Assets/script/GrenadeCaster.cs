using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Transform FireballSource;
    public Rigidbody grenadePrefab;
    public float forse = 10;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = FireballSource.position;
            grenade.GetComponent<Rigidbody>().AddForce(FireballSource.forward * forse);
        }
    }
}
