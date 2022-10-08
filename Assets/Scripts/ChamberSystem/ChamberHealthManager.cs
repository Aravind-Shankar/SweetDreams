using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberHealthManager : MonoBehaviour
{
    public int maxHealth = 2;
    public int health = 0;

    public bool FeedFood()
    {
        // return true if fed successfully, false if not (e.g. when health is full)
        if (health < maxHealth)
        {
            ++health;
            return true;
        }
        else
            return false;
    }
}
