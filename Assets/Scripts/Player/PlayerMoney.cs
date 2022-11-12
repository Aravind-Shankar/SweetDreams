using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public int startingMoney = 100;
    public Text moneyText;

    int _money;
    public int Money
    {
        get { return _money; }
        set { _money = Mathf.Max(value, 0); moneyText.text = _money.ToString(); }
    }

    private void Start()
    {
        Money = startingMoney;
    }
}
