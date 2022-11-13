using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    public bool hasFood = false;

    private void OnTriggerEnter(Collider other)
    {
        ChamberFoodItem chamberFoodItem = other.gameObject.GetComponent<ChamberFoodItem>();
        if (chamberFoodItem != null)
        {
            if (!hasFood)
            {
                hasFood = true;
                Destroy(other.gameObject);
            }
            return;
        }

        ChamberHealthManager chamberHealthManager = other.gameObject.GetComponent<ChamberHealthManager>();
        if (chamberHealthManager != null)
        {
            if (hasFood)
            {
                chamberHealthManager.FeedFood();
                hasFood = false;
            }
            return;
        }
    }
}
