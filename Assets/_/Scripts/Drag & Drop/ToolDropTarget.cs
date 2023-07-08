using System;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class ToolDropTarget : DropTarget
{
    [Header("Tool Info")]

    [SerializeField]
    private ToolScriptableObject toolData;
    private RecipeManager recipeManager;
    private IngredientsAddressablesManager ingredientsManager;

    private void Awake()
    {
        this.recipeManager = FindObjectOfType<RecipeManager>();
        this.ingredientsManager = FindObjectOfType<IngredientsAddressablesManager>();
    }

    private void Start()
    {
        AcceptDropIfNoErrorIsThrown.AddListener(ValidateDraggableOnDrop);
        OnSuccessfulDrop.AddListener(OutputRecipe);
        OnSuccessfulDrop.AddListener(DeleteDroppedDraggable);
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
        this.recipeManager.InstantiateIngredientsFromRecipe(ingredientDraggable.Data.id, this.toolData.id);
    }
}
