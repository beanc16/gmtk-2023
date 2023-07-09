using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Beanc16.Common.Mechanics.DragAndDrop;

public class VictoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryModal;
    [SerializeField]
    private TextMeshProUGUI victoryModalMovesTextComponent;
    [SerializeField]
    private TextMeshProUGUI victoryModalEfficiencyChallengeTextComponent;
    private GoalIngredientDropTarget goalIngredientDropTarget;
    private bool victoryTriggered = false;
    private LevelManager levelManager;
    private MoveTracker moveTracker;

    private bool MoveCountIsOptimal
    {
        get { return this.moveTracker.MoveCount <= this.levelManager.LevelData.optimalNumberOfMoves; }
    }

    private void Awake()
    {
        this.goalIngredientDropTarget = FindObjectOfType<GoalIngredientDropTarget>();
        this.levelManager = FindObjectOfType<LevelManager>();
        this.moveTracker = FindObjectOfType<MoveTracker>();
        this.victoryModal.SetActive(false);
    }

    private void Start()
    {
        // TODO: This is getting triggered in the incorrect order. Make it go after the completed list is updated later.
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

        // Number of moves made
        // Blank line necessary for spacing
        this.victoryModalMovesTextComponent.text = "\n" + this.moveTracker.MoveCount.ToString();
        this.victoryModalMovesTextComponent.color = (this.MoveCountIsOptimal)
            ? new Color32(70, 232, 208, 255)    // Green
            : new Color32(245, 35, 35, 255);    // Red

        // Optimal number of moves for this level
        this.victoryModalEfficiencyChallengeTextComponent.text = "Efficiency challenge:\n" + this.levelManager.LevelData.optimalNumberOfMoves + " or less moves";
    }
}
