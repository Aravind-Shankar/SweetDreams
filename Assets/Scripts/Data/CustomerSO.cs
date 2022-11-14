using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customers", menuName = "ScriptableObjects/CustomerSO", order = 1)]
public class CustomerSO : ScriptableObject
{
    public GameObject customerPrefab;
    public PotionSO potionSO;

    [Tooltip("Elements should be in order of arrival time.")]
    public Customer[] customers;
}

[System.Serializable]
public class Customer
{
    public int arrivalTime;
    public string name;
    public int orderedPotionID;

    private CustomerAI _customerAI;

    public override string ToString()
    {
        return arrivalTime.ToString() + ", " + name + ", " + orderedPotionID.ToString();
    }
}