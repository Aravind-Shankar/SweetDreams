using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Potions", menuName = "ScriptableObjects/PotionSO", order = 1)]
public class PotionSO : ScriptableObject
{
    public IngredientSO ingredientSO;
    public Potion wildcardPotion;

    [Tooltip("Ensure: array indices match the ids of the respective elements.")]
    public Potion[] potions;

    public Potion FindMatchingPotion(Dictionary<int, int> queryIngredientFrequency)
    {
        foreach (var potion in potions)
            if (potion.IngredientsMatching(queryIngredientFrequency))
                return potion;

        wildcardPotion.ingredientFrequency = queryIngredientFrequency;
        return wildcardPotion;
    }
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

    [HideInInspector]
    public Dictionary<int, int> ingredientFrequency;

    public bool IngredientsMatching(Dictionary<int, int> queryIngredientFrequency)
    {
        if (ingredientFrequency == null)
        {
            ingredientFrequency = new Dictionary<int, int>();
            foreach (var pair in ingredientComposition)
            {
                if (ingredientFrequency.ContainsKey(pair.id))
                    ingredientFrequency[pair.id]++;
                else
                    ingredientFrequency[pair.id] = 1;
            }
        }

        foreach (var id in ingredientFrequency.Keys)
            if (!queryIngredientFrequency.ContainsKey(id) || queryIngredientFrequency[id] != ingredientFrequency[id])
                return false;

        foreach (var id in queryIngredientFrequency.Keys)
            if (!ingredientFrequency.ContainsKey(id) || queryIngredientFrequency[id] != ingredientFrequency[id])
                return false;

        return true;
    }
}