using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject drinkObject;
    public Transform drinkPos;
    public GameObject chamberParent;

    private ChamberHealthManager[] chamberHealthManagers;

    private void Start()
    {
        chamberHealthManagers = chamberParent.GetComponentsInChildren<ChamberHealthManager>();
    }

    public void OnTriggerEnter(Collider other) {
        DrinkManager dm = other.GetComponent<DrinkManager>();
        if (dm)
            MakeDrink(dm);
    }

    private bool TryUseChamber()
    {
        int numChambers = chamberHealthManagers.Length;
        int rnd;
        ChamberHealthManager temp;

        for (int i = 0; i < numChambers - 1; i++)
        {
            rnd = Random.Range(i, numChambers);
            temp = chamberHealthManagers[i];
            chamberHealthManagers[i] = chamberHealthManagers[rnd];
            chamberHealthManagers[rnd] = temp;
        }

        foreach(ChamberHealthManager chm in chamberHealthManagers)
        {
            if (chm.UseForDrink())
            {
                print($"Used chamber: {chm.gameObject.name}");
                return true;
            }
        }
        print("No chamber available!");
        return false;
    }

    private void MakeDrink(DrinkManager dm)
    {
        if (dm.hasDrink || !TryUseChamber())
            return;

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
