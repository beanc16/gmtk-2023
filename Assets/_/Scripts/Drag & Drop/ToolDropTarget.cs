using System;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.General;
using Beanc16.Common.Mechanics.DragAndDrop;

public class ToolDropTarget : DropTarget
{
    [Header("Tool Info")]

    [SerializeField]
    private ToolScriptableObject toolData;
    private RecipeManager recipeManager;
    private IngredientsAddressablesManager ingredientsManager;
    private ToolDropTargetBackgroundsManager toolDropTargetBackgroundsManager;
    [SerializeField]
    private GameObjectToggleHandler backgroundToggleHandler;

    private void Awake()
    {
        this.recipeManager = FindObjectOfType<RecipeManager>();
        this.ingredientsManager = FindObjectOfType<IngredientsAddressablesManager>();
        this.toolDropTargetBackgroundsManager = FindObjectOfType<ToolDropTargetBackgroundsManager>();
    }

    private void Start()
    {
        AcceptDropIfNoErrorIsThrown.AddListener(ValidateDraggableOnDrop);
        OnSuccessfulDrop.AddListener(OutputRecipe);
        OnSuccessfulDrop.AddListener(DeleteDroppedDraggable);
        OnSuccessfulDrop.AddListener((Draggable draggable) => this.toolDropTargetBackgroundsManager.ToggleAllBackgroundVisibilities(false));
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

    public void ToggleBackgroundVisibility(bool shouldBeVisible)
    {
        this.backgroundToggleHandler.ToggleVisibility(shouldBeVisible);
    }
}
