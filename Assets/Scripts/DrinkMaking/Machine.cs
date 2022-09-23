using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        DrinkManager dm = other.GetComponent<DrinkManager>();
        if (dm && dm.hasItem) {
            other.GetComponent<DrinkManager>().hasDrink = true;
            other.GetComponent<DrinkManager>().hasItem = false;
        }
    }
}
