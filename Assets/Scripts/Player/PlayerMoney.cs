using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public int startingMoney = 100;

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
