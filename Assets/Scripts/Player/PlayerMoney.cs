using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int startingMoney = 100;

    int _money;
    public int Money
    {
        get { return _money; }
        set { _money = Mathf.Max(value, 0); }
    }

    private void Start()
    {
        Money = startingMoney;
    }
}
