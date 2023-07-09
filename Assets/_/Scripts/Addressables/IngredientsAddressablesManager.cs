using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IngredientsAddressablesManager : AddressablesManager
{
    [Header("Ingredients Info")]

    [SerializeField]
    private List<IngredientScriptableObject> ingredients;

    [Header("Ingredient Events")]
    public UnityEvent OnIngredientsLoadSuccess;



    private void Start()
    {
        OnAssetLoadSuccess.AddListener(InitializeRecipeMap);
    }

    private void InitializeRecipeMap(List<ScriptableObject> scriptableObjects)
    {
        this.ingredients = scriptableObjects
            .Select(scriptableObject => (IngredientScriptableObject)scriptableObject)
            .ToList();

        this.TryCallOnIngredientsLoadSuccessEvent();
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

    private void TryCallOnIngredientsLoadSuccessEvent()
    {
        if (this.OnIngredientsLoadSuccess != null)
        {
            this.OnIngredientsLoadSuccess.Invoke();
        }
    }
}
