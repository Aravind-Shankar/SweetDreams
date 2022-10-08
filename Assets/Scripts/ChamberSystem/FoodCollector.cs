using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    public bool hasFood = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasFood)
            return;

        if (other.gameObject.GetComponent<ChamberFoodItem>() != null)
        {
            hasFood = true;
            Destroy(other.gameObject);
        }
    }
}
