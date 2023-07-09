using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ToolDropTargetBackgroundsManager : MonoBehaviour
{
    private List<GoalIngredientDropTarget> goalDropTargets = new List<GoalIngredientDropTarget>();
    private List<ToolDropTarget> toolDropTargets = new List<ToolDropTarget>();



    private void Awake()
    {
        this.goalDropTargets = FindObjectsOfType<GoalIngredientDropTarget>().ToList();
        this.toolDropTargets = FindObjectsOfType<ToolDropTarget>().ToList();
        this.ToggleAllBackgroundVisibilities(false);
    }

    public void ToggleAllBackgroundVisibilities(bool shouldBeVisible)
    {
        this.goalDropTargets.ForEach(goalDropTarget =>
            goalDropTarget.ToggleBackgroundVisibility(shouldBeVisible)
        );
        this.toolDropTargets.ForEach(toolDropTarget =>
            toolDropTarget.ToggleBackgroundVisibility(shouldBeVisible)
        );
    }
}
