using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    public string name;
    public int arrivalTime;
    public string orderedPotionName;

    public override string ToString()
    {
        return arrivalTime.ToString() + ", " + name + ", " + orderedPotionName;
    }
}