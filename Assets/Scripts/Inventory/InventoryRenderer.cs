using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    private Inventory inventory;
    private GameObject player;

    private GameObject itemToRender;
    private GameObject itemFromLastFrame;
    private GameObject currentItem;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentItem = inventory.GetCurrentItem();
        currentItem.transform.localPosition = player.transform.position + (new Vector3(.5f, 1, .5f));
    }
}
