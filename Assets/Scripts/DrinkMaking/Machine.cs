using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject drinkObject;
    public Transform drinkPos;

    public void OnTriggerEnter(Collider other) {
        DrinkManager dm = other.GetComponent<DrinkManager>();
        if (dm && !dm.hasDrink) {
            dm.hasDrink = true;
            if (dm.hasItem)
                dm.hasItem = false;

            drinkObject.transform.parent = null;
            drinkObject.transform.localScale = Vector3.one;

            drinkObject.transform.SetParent(drinkPos, false);
            drinkObject.transform.localPosition = Vector3.zero;
            drinkObject.transform.localRotation = Quaternion.identity;

            drinkObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
