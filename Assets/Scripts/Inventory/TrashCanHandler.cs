using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private Inventory inventory;
    
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowawayItem()
    {
        if (inventory.HasItem())
        {
            inventory.RemoveItem();
            EventLog.LogInfo("Held item disposed");
        }
        else
            EventLog.LogError("No held item to dispose!");
    }
}
