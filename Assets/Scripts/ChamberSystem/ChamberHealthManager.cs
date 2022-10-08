using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberHealthManager : MonoBehaviour
{
    public int maxHealth = 2;
    public int health = 0;

    public bool FeedFood()
    {
        // return true if fed successfully, false if not (e.g. when health is maxed)
        if (health < maxHealth)
        {
            ++health;
            return true;
        }
        else
            return false;
    }

    public bool UseForDrink()
    {
        // return true if used successfully, false if not (e.g. when health is insufficient)
        if (health == 0)
            return false;
        --health;
        return true;
    }
}
