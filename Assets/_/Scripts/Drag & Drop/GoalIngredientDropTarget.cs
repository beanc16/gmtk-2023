using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.General;
using Beanc16.Common.Mechanics.DragAndDrop;

public class GoalIngredientDropTarget : DropTarget
{
    [Header("Goal Data")]

    [SerializeField]
    private List<IngredientScriptableObject> orderedIngredients = new List<IngredientScriptableObject>();
    private List<IngredientScriptableObject> completedIngredients = new List<IngredientScriptableObject>();
    private List<GoalIngredientPanel> goalIngredientPanels = new List<GoalIngredientPanel>();
    [SerializeField]
    private GameObjectToggleHandler backgroundToggleHandler;

    public bool HasWon
    {
        get { return this.completedIngredients.Count == this.orderedIngredients.Count; }
    }



    private void Awake()
    {
        this.goalIngredientPanels = FindObjectsOfType<GoalIngredientPanel>().ToList();
        this.backgroundToggleHandler = this.GetComponent<GameObjectToggleHandler>();
    }

    private void Start()
    {
        AcceptDropIfNoErrorIsThrown.AddListener(ValidateDraggableOnDrop);
        OnSuccessfulDrop.AddListener(DeleteDroppedDraggable);
        OnSuccessfulDrop.AddListener(AddCompletedIngredient);
        OnSuccessfulDrop.AddListener(ToggleCompletionMarkOnGoalIngredient);
    }

    private void ValidateDraggableOnDrop(Draggable draggable)
    {
        IngredientDraggable ingredientDraggable = (IngredientDraggable)draggable;

        if (ingredientDraggable == null)
        {
            throw new Exception("IngredientDraggable was not dragged onto GoalIngredientDropTarget");
        }

        else
        {
            bool isOrderedIngredient = this.orderedIngredients.Any(orderedIngredient =>
                orderedIngredient.id == ingredientDraggable.Data.id
            );

            if (!isOrderedIngredient)
            {
                throw new Exception("IngredientDraggable is not an ordered ingredient");
            }
        }
    }

    private void AddCompletedIngredient(Draggable draggable)
    {
        IngredientDraggable ingredientDraggable = (IngredientDraggable)draggable;
        this.completedIngredients.Add(ingredientDraggable.Data);
    }

    private void ToggleCompletionMarkOnGoalIngredient(Draggable draggable)
    {
        IngredientDraggable ingredientDraggable = (IngredientDraggable)draggable;

        GoalIngredientPanel goalIngredientPanel = goalIngredientPanels.Find(goalIngredientPanel =>
            goalIngredientPanel.Data.id == ingredientDraggable.Data.id
        );
        goalIngredientPanel.ToggleCompletionMark(true);
    }

    public void ToggleBackgroundVisibility(bool shouldBeVisible)
    {
        this.backgroundToggleHandler.ToggleVisibility(shouldBeVisible);
    }
}
