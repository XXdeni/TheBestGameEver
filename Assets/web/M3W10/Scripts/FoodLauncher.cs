using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public Food FoodPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowFood();
        }
    }

    void ThrowFood()
    {
        Food foodClone = Instantiate(FoodPrefab, transform.position, transform.rotation);
        foodClone.transform.LookAt(GetTargetPoint());
    }

    Vector3 GetTargetPoint()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
}
