using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDrink : MonoBehaviour
{
    public GameObject drinkObject;
    public void OnTriggerEnter(Collider other) {
        DrinkManager dm = other.GetComponent<DrinkManager>();
        if (dm && dm.hasDrink) {
            dm.hasDrink = false;

            drinkObject.transform.parent = null;
            drinkObject.transform.localScale = Vector3.one;

            drinkObject.transform.SetParent(transform);
            drinkObject.transform.localPosition = Vector3.zero;
            drinkObject.transform.localRotation = Quaternion.identity;
        }
    }
}
