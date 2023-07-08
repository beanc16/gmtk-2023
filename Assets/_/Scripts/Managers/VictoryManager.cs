using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryModal;
    private GoalIngredientDropTarget goalIngredientDropTarget;

    private void Awake()
    {
        this.goalIngredientDropTarget = FindObjectOfType<GoalIngredientDropTarget>();
    }

    private void Start()
    {
        this.goalIngredientDropTarget.OnSuccessfulDrop.AddListener(TryTriggerVictory);
    }

    private void TryTriggerVictory(Draggable draggable)
    {
        if (this.goalIngredientDropTarget.HasWon)
        {
            this.TriggerVictory();
        }
    }

    private void TriggerVictory()
    {
        this.victoryModal.SetActive(true);

        // Make it so that any leftover draggables can't be dragged
        List<Draggable> draggables = FindObjectsOfType<Draggable>().ToList();
        draggables.ForEach(draggable => draggable.ToggleInteractivity(false));
    }
}
