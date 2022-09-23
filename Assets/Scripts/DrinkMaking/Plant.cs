using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if (other.GetComponent<DrinkManager>()) {
            other.GetComponent<DrinkManager>().hasItem = true;
            Destroy(gameObject);
        }
    }
}
