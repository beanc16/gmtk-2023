using UnityEngine;
using UnityEngine.UI;
using Beanc16.Common.Mechanics.DragAndDrop;

public class IngredientPanel : MonoBehaviour
{
    [SerializeField]
    protected IngredientScriptableObject ingredientData;
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

    public void RefreshSprite()
    {
        if (this.ingredientData != null)
        {
            this.ingredientImage.sprite = this.ingredientData.sprite;
        }
    }

    public void RefreshSprite(Image image)
    {
        if (this.ingredientData != null)
        {
            image.sprite = this.ingredientData.sprite;
        }
    }
}
