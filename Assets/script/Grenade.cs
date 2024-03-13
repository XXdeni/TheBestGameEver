using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explorePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explore", delay);
    }
    private void Explore()
    {
        Destroy(gameObject);
        var explore = Instantiate(explorePrefab);
        explore.transform.position = transform.position;
    }
}
