using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Beanc16.Common.Mechanics.DragAndDrop;

public class MoveTracker : MonoBehaviour
{
    private List<DropTarget> dropTargets;
    private int moveCount = 0;

    public int MoveCount
    {
        get { return this.moveCount; }
    }



    private void Awake()
    {
        this.dropTargets = FindObjectsOfType<DropTarget>().ToList();
    }

    private void Start()
    {
        this.dropTargets.ForEach(dropTarget =>
            dropTarget.OnSuccessfulDrop.AddListener(IncrementMoveCount)
        );
    }



    private void IncrementMoveCount(Draggable draggable)
    {
        this.moveCount++;
    }
}
