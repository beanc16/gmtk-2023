using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsAddressablesManager : AddressablesManager
{
    [Header("Ingredients Info")]

    [SerializeField]
    private List<IngredientScriptableObject> ingredients;



    private void Start()
    {
        OnAssetLoadSuccess.AddListener(InitializeRecipeMap);
    }

    private void InitializeRecipeMap(List<ScriptableObject> scriptableObjects)
    {
        this.ingredients = scriptableObjects
            .Select(scriptableObject => (IngredientScriptableObject)scriptableObject)
            .ToList();
    }

    public IngredientScriptableObject GetById(IngredientId ingredientId)
    {
        return this.ingredients
            .FirstOrDefault(ingredient =>
                ingredient.id == ingredientId
            );
    }

    public List<IngredientScriptableObject> GetByIds(List<IngredientId> ingredientIds)
    {
        return this.ingredients
            .Where(ingredient =>
                ingredientIds.Contains(ingredient.id)
            )
            .ToList();
    }
}
