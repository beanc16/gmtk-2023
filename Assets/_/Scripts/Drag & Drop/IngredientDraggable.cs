using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class IngredientDraggable : Draggable
{
    [Header("Ingredient Info")]

    [SerializeField]
    private IngredientScriptableObject ingredientData;

    public IngredientScriptableObject Data
    {
        get { return ingredientData; }
    }
}
