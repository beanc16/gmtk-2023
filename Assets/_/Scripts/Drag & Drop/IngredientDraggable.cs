using UnityEngine;
using UnityEngine.UI;
using Beanc16.Common.Mechanics.DragAndDrop;

public class IngredientDraggable : Draggable
{
    [Header("Ingredient Info")]

    [SerializeField]
    private IngredientScriptableObject ingredientData;
    private Image ingredientImage;

    public IngredientScriptableObject Data
    {
        get { return ingredientData; }
        private set {
            this.ingredientData = value;
            this.RefreshSprite();
        }
    }

    public void SetData(IngredientScriptableObject data)
    {
        this.Data = data;
    }



    private void OnEnable()
    {
        this.ingredientImage = this.GetComponentInChildren<Image>();
        this.RefreshSprite();
    }

    private void RefreshSprite()
    {
        if (this.ingredientData != null)
        {
            this.ingredientImage.sprite = this.ingredientData.sprite;
        }
    }
}
