using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyUpdateText;

    public int startingMoney = 100;

    private Animator moneyUpdateAnimator;
    private int animUpdateTriggerID;
    private int animUpdateAmountID;

    private int _money;
    public int Money
    {
        get { return _money; }
        set
        {
            int newValue = Mathf.Max(value, 0);
            int change = newValue - _money;
            _money = newValue;
            moneyText.text = _money.ToString();

            if (moneyUpdateAnimator != null)
            {
                moneyUpdateText.text = ((change > 0) ? "+" : "") + change.ToString();
                moneyUpdateAnimator.SetInteger(animUpdateAmountID, change);
                moneyUpdateAnimator.SetTrigger(animUpdateTriggerID);
            }
        }
    }

    private void Start()
    {
        Money = startingMoney;

        moneyUpdateAnimator = moneyUpdateText.gameObject.GetComponent<Animator>();
        animUpdateTriggerID = Animator.StringToHash("updateTrigger");
        animUpdateAmountID = Animator.StringToHash("updateAmount");
    }
}
