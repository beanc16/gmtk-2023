using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RecipeAddressablesManager : AddressablesManager
{
    [Header("Recipe Info")]

    [SerializeField]
    private IngredientScriptableObject defaultOutput;
    private List<RecipeScriptableObject> recipes;



    private void Start()
    {
        OnAssetLoadSuccess.AddListener(InitializeRecipeMap);
    }

    private void InitializeRecipeMap(List<ScriptableObject> scriptableObjects)
    {
        this.recipes = scriptableObjects
            .Select(scriptableObject => (RecipeScriptableObject)scriptableObject)
            .ToList();
    }

    public List<IngredientId> GetRecipeOutput(IngredientId inputIngredientId, ToolId toolId)
    {
        RecipeScriptableObject recipe = this.recipes
            .FirstOrDefault(recipe =>
                recipe.inputIngredientId == inputIngredientId
                && recipe.toolId == toolId
            );
        
        return recipe?.outputIngredientIds ?? new List<IngredientId> {
            this.defaultOutput.id
        };
    }
}
