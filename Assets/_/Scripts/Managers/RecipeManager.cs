using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class RecipeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ingredientPanelPrefab;

    private RecipeAddressablesManager recipesManager;
    private IngredientsAddressablesManager ingredientsManager;
    private List<IngredientDropTarget> ingredientDropTargets = new List<IngredientDropTarget>();

    private void Awake()
    {
        this.recipesManager = FindObjectOfType<RecipeAddressablesManager>();
        this.ingredientsManager = FindObjectOfType<IngredientsAddressablesManager>();
        this.ingredientDropTargets = FindObjectsOfType<IngredientDropTarget>().ToList();
    }

    public void InstantiateIngredientsFromRecipe(IngredientId inputIngredientId, ToolId toolId)
    {
        List<IngredientId> outputIngredientIds = this.recipesManager.GetRecipeOutput(inputIngredientId, toolId);
        List<IngredientScriptableObject> outputIngredients = this.ingredientsManager.GetByIds(outputIngredientIds);

        outputIngredients.ForEach(ingredient => {
            IngredientDropTarget firstEmptyDropTarget = this.ingredientDropTargets
                .First(dropTarget =>
                    dropTarget.GetComponentInChildren<IngredientDraggable>() == null
                );

            GameObject ingredientGameObject = Instantiate(this.ingredientPanelPrefab, firstEmptyDropTarget.transform);
            IngredientDraggable ingredientDraggable = ingredientGameObject.GetComponent<IngredientDraggable>();
            ingredientDraggable.SetData(ingredient);
        });
    }
}
