using System;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class IngredientDropTarget : DropTarget
{
    private void Start()
    {
        AcceptDropIfNoErrorIsThrown.AddListener(ValidateDraggableOnDrop);
    }

    private void ValidateDraggableOnDrop(Draggable draggable)
    {
        IngredientDraggable childDraggable = this.GetComponentInChildren<IngredientDraggable>();

        if (childDraggable != null)
        {
            throw new Exception("IngredientDraggable already exists in IngredientDropTarget");
        }
    }
}
