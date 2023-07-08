using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class GoalIngredientDropTarget : DropTarget
{
    [Header("Goal Data")]

    [SerializeField]
    private List<IngredientScriptableObject> orderedIngredients = new List<IngredientScriptableObject>();
    private List<IngredientScriptableObject> completedIngredients = new List<IngredientScriptableObject>();

    private bool HasWon
    {
        get { return this.completedIngredients.Count == this.orderedIngredients.Count; }
    }

    private void Start()
    {
        AcceptDropIfNoErrorIsThrown.AddListener(ValidateDraggableOnDrop);
        OnSuccessfulDrop.AddListener(DeleteDroppedDraggable);
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

            else
            {
                completedIngredients.Add(ingredientDraggable.Data);
            }

            if (this.HasWon)
            {
                // TODO: Delete this later
                Debug.Log("You win!");
            }
        }
    }
}
