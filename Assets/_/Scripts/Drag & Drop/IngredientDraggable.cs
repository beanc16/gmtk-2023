using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Beanc16.Common.Mechanics.DragAndDrop;

[RequireComponent(typeof (IngredientPanel))]
public class IngredientDraggable : Draggable
{
    private IngredientPanel ingredientPanel;
    private ToolDropTargetBackgroundsManager toolDropTargetBackgroundsManager;

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
        this.toolDropTargetBackgroundsManager = FindObjectOfType<ToolDropTargetBackgroundsManager>();
        this.ingredientPanel = this.GetComponent<IngredientPanel>();
        this.RefreshSprite();
        OnDragStart.AddListener(() => this.toolDropTargetBackgroundsManager.ToggleAllBackgroundVisibilities(true));
        OnDragEnd.AddListener(() => this.toolDropTargetBackgroundsManager.ToggleAllBackgroundVisibilities(false));
    }

    private void RefreshSprite()
    {
        this.ingredientPanel.RefreshSprite();
    }
}
