using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Potions", menuName = "ScriptableObjects/PotionSO", order = 1)]
public class PotionSO : ScriptableObject
{
    public IngredientSO ingredientSO;

    [Tooltip("Ensure: array indices match the ids of the respective elements.")]
    public Potion[] potions;
}

[System.Serializable]
public struct IngredientIDCountPair
{
    public int id;
    public int count;
}

[System.Serializable]
public class Potion
{
    public string name;
    public int id;
    public IngredientIDCountPair[] ingredientComposition;
    public int sellingPrice;
    public Sprite icon;
    public ItemType itemType;
}