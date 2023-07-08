using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RecipeScriptableObject", order = 1)]
public class RecipeScriptableObject : ScriptableObject
{
    public IngredientId inputIngredientId;
    public ToolId toolId;
    public List<IngredientId> outputIngredientIds = new List<IngredientId>();



    public override string ToString()
    {
        return base.ToString() + "\n"
            + "{" + "\n\t"
            + "inputIngredientId: " + this.inputIngredientId.ToString() + "\n\t"
            + "toolId: " + this.toolId.ToString() + "\n\t"
            + "outputIngredientIds: " + this.outputIngredientIds.ToString() + "\n"
            + "}";
    }
}
