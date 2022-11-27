using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredients", menuName = "ScriptableObjects/IngredientSO", order = 1)]
public class IngredientSO : ScriptableObject
{
    public Ingredient[] ingredients;
}

[System.Serializable]
public class Ingredient
{
    public string name;
    public string description;
    public int cost;
}