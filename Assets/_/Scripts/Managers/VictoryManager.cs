using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryModal;
    private GoalIngredientDropTarget goalIngredientDropTarget;
    private bool victoryTriggered = false;

    private void Awake()
    {
        this.goalIngredientDropTarget = FindObjectOfType<GoalIngredientDropTarget>();
    }

    private void Start()
    {
        // this.goalIngredientDropTarget.OnSuccessfulDrop.AddListener(TryTriggerVictory);
    }

    private void Update()
    {
        this.TryTriggerVictory();
    }

    private void TryTriggerVictory()
    {
        if (!this.victoryTriggered && this.goalIngredientDropTarget.HasWon)
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

        this.victoryTriggered = true;
    }
}
