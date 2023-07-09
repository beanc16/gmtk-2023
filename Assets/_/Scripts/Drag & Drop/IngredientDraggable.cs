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



    private void Start()
    {
        this.OnEnable();
    }

    private void OnEnable()
    {
        this.toolDropTargetBackgroundsManager = FindObjectOfType<ToolDropTargetBackgroundsManager>();
        this.ingredientPanel = this.GetComponent<IngredientPanel>();
        this.RefreshSprite();
        OnDragStart.AddListener(() => this.ToggleAllBackgroundVisibilities(true));
        OnDragEnd.AddListener(() => this.ToggleAllBackgroundVisibilities(false));
    }

    private void RefreshSprite()
    {
        this.ingredientPanel.RefreshSprite();
    }

    private void ToggleAllBackgroundVisibilities(bool shouldBeVisible)
    {
        if (this.toolDropTargetBackgroundsManager == null)
        {
            this.toolDropTargetBackgroundsManager = FindObjectOfType<ToolDropTargetBackgroundsManager>();
        }

        this.toolDropTargetBackgroundsManager.ToggleAllBackgroundVisibilities(shouldBeVisible);
    }
}
