using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDrink : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        DrinkManager dm = other.GetComponent<DrinkManager>();
        if (dm && dm.hasDrink) {
            other.GetComponent<DrinkManager>().hasDrink = false;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
