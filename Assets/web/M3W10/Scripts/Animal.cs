using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public List<Transform> PatrolPoints;

    //задай минимальный и максимальный размер животного
    public float MaxScale = 20;
    public float MinScale = 5;

    //задай скорость уменьшения и увеличения размера
    public float ScaleDecrease = 1;
    public float ScaleIncrease = 10;

    NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Patrol();
        Starve();
    }

    void Patrol()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
        }
    }

    //Метод постоянного голода. Плавно уменьшает размер животного и уничтожает его, если он становится слишком маленьким
    void Starve()
    {
        //уменьшаем размер животного на ScaleDecrease в секунду
        transform.localScale -= ScaleDecrease * Time.deltaTime * Vector3.one;

        //Если размер животного стал слишком маленьким, то уничтожаем его
        if (transform.localScale.x < MinScale)
        {
            Destroy(gameObject);
        }
    }

    //Метод увеличения размера животного при попадании в него еды
    public void EatFood()
    {
        //Увеличиваем размер животного на ScaleIncrease
        transform.localScale += ScaleIncrease * Time.deltaTime * Vector3.one;

        //Если размер животного стал слишком большим, то делаем размер равным MaxScale
        if (transform.localScale.x > MaxScale)
        {
            transform.localScale = Vector3.one * MaxScale;
        }
    }
}