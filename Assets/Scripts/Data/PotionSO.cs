using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Potions", menuName = "ScriptableObjects/PotionSO", order = 1)]
public class PotionSO : ScriptableObject
{
    public IngredientSO ingredientSO;
    public Sprite potionIconBase;
    public Potion wildcardPotion;

    public Potion[] potions;

    private Dictionary<string, Potion> _potionsDict = null;
    public Potion LookupPotionByName(string potionName)
    {
        if (_potionsDict == null)
        {
            _potionsDict = new Dictionary<string, Potion>();
            foreach (var potion in potions)
            {
                _potionsDict.Add(potion.name, potion);
            }
        }

        return _potionsDict[potionName];
    }

    public Potion LookupPotionByIngredients(Dictionary<string, int> queryIngredientFrequency)
    {
        foreach (var potion in potions)
            if (potion.IngredientsMatching(queryIngredientFrequency))
                return potion;

        wildcardPotion.ingredientFrequency = queryIngredientFrequency;
        return wildcardPotion;
    }
}

[System.Serializable]
public struct IngredientNameCountPair
{
    public string ingredientName;
    public int count;
}

[System.Serializable]
public class Potion
{
    public string name;
    public IngredientNameCountPair[] ingredientComposition;
    public int sellingPrice;
    public Color color = Color.white;

    [HideInInspector]
    public Dictionary<string, int> ingredientFrequency;

    public bool IngredientsMatching(Dictionary<string, int> queryIngredientFrequency)
    {
        if (ingredientFrequency == null)
        {
            ingredientFrequency = new Dictionary<string, int>();
            foreach (var pair in ingredientComposition)
            {
                ingredientFrequency[pair.ingredientName] = pair.count;
            }
        }

        foreach (var name in ingredientFrequency.Keys)
            if (!queryIngredientFrequency.ContainsKey(name) || queryIngredientFrequency[name] != ingredientFrequency[name])
                return false;

        foreach (var name in queryIngredientFrequency.Keys)
            if (!ingredientFrequency.ContainsKey(name) || queryIngredientFrequency[name] != ingredientFrequency[name])
                return false;

        return true;
    }
}