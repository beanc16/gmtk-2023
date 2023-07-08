using UnityEngine;
using UnityEngine.UI;
using Beanc16.Common.Mechanics.DragAndDrop;

[RequireComponent(typeof (IngredientPanel))]
public class IngredientDraggable : Draggable
{
    private IngredientPanel ingredientPanel;

    public IngredientScriptableObject Data
    {
        get { return this.ingredientPanel.Data; }
    }

    public void SetData(IngredientScriptableObject data)
    {
        this.ingredientPanel.SetData(data);
    }



    private void OnEnable()
    {
        this.ingredientPanel = this.GetComponent<IngredientPanel>();
        this.RefreshSprite();
    }

    private void RefreshSprite()
    {
        this.ingredientPanel.RefreshSprite();
    }
}
