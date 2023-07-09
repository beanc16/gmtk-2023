using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelScriptableObject", order = 4)]
public class LevelScriptableObject : ScriptableObject
{
    public int optimalNumberOfMoves = 0;
    public List<IngredientId> startingIngredientIds = new List<IngredientId>();
    public List<IngredientId> orderIngredientIds = new List<IngredientId>();



    public override string ToString()
    {
        return base.ToString() + "\n"
            + "{" + "\n\t"
            + "optimalNumberOfMoves: " + this.optimalNumberOfMoves.ToString() + "\n\t"
            + "startingIngredientIds: [" + string.Join(", ", this.startingIngredientIds) + "]\n\t"
            + "orderIngredientIds: [" + string.Join(", ", this.orderIngredientIds) + "]\n"
            + "}";
    }
}
