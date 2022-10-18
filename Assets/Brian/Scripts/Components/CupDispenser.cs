using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupDispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    public Inventory inventory;
    public GameObject cup;
    public GameObject player;
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        //cup = Instantiate(cupPrefab, new Vector3(-1, -1, -1), Quaternion.identity);
    }

    public void DispenseCup()
    {
        // play cup dispensing sound
        // play particles for dispensing a cup
        //cup.transform.position = this.transform.position + new Vector3(0, 0, 3);
        // put it in player inventory
        if (inventory.ContainsItem("Cup"))
        {

        } else
        {
            Debug.Log("Dispense");
            GameObject newCup = Instantiate(cup, new Vector3(-1, -1, -1), Quaternion.identity);
            inventory.AddItem(newCup);

            // make cup child of polyman
            newCup.transform.SetParent(player.transform);

            newCup.transform.localPosition = new Vector3(.5f, 1, .5f);
        }
        

    }
}
