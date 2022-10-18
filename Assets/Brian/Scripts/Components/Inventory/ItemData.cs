using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{

    public System.Guid id;
    public string title;

    public ItemData(string title)
    {
        this.id = System.Guid.NewGuid();
        this.title = title;
    }
}
