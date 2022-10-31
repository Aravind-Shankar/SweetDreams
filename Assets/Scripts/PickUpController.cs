using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentPickUp;

    private void Awake()
    {
        currentPickUp = new GameObject();
    }


}
