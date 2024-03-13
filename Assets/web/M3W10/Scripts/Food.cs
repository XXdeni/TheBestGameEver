using UnityEngine;

public class Food : MonoBehaviour
{
    
    public float _speed = 50;
    void Start()
    {
        
        Destroy(gameObject, 10f);
        //Задаем начальную скорость полета еды
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Пробуем взять компонент Animal у объекта, с которым столкнулась еда
        Animal animal = collision.gameObject.GetComponent<Animal>();

        //Если у объекта есть компонент Animal, то вызываем у него метод EatFood и уничтожаем еду
        if (animal != null)
        {
            animal.EatFood();
            Destroy(gameObject);
        }
    }
}