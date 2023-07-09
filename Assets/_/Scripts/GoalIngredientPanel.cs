using UnityEngine;
using UnityEngine.UI;
using Beanc16.Common.Mechanics.DragAndDrop;

public class GoalIngredientPanel : IngredientPanel
{
    [SerializeField]
    private GameObject completionMarkPanel;
    [SerializeField]
    private Image ingredientImageOverride;



    private void Start()
    {
        this.OnEnable();
    }

    private void OnEnable()
    {
        this.RefreshSprite();
    }

    public void ToggleCompletionMark(bool isComplete)
    {
        this.completionMarkPanel.SetActive(isComplete);
    }

    public new void RefreshSprite()
    {
        this.RefreshSprite(this.ingredientImageOverride);
    }
}
