using System;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class ToolDropTarget : DropTarget
{
    [Header("Tool Info")]

    [SerializeField]
    private ToolScriptableObject toolData;
    private RecipeAddressablesManager recipesManager;
    private IngredientsAddressablesManager ingredientsManager;

    private void Awake()
    {
        this.recipesManager = FindObjectOfType<RecipeAddressablesManager>();
        this.ingredientsManager = FindObjectOfType<IngredientsAddressablesManager>();
    }

    private void Start()
    {
        AcceptDropIfNoErrorIsThrown.AddListener(ValidateDraggableOnDrop);
        OnSuccessfulDrop.AddListener(OutputRecipe);
    }

    private void ValidateDraggableOnDrop(Draggable draggable)
    {
        IngredientDraggable ingredientDraggable = draggable.GetComponent<IngredientDraggable>();

        if (ingredientDraggable == null)
        {
            throw new Exception("IngredientDraggable was not dragged onto ToolDropTarget");
        }
    }

    private void OutputRecipe(Draggable draggable)
    {
        IngredientDraggable ingredientDraggable = (IngredientDraggable)draggable;
        List<IngredientId> outputIngredientIds = recipesManager.GetRecipeOutput(ingredientDraggable.Data.id, this.toolData.id);

        List<IngredientScriptableObject> ingredients = this.ingredientsManager.GetByIds(outputIngredientIds);

        // TODO: Delete this function later
        ingredients.ForEach(ingredient => Debug.Log(ingredient));

        Destroy(ingredientDraggable.gameObject);
    }
}
