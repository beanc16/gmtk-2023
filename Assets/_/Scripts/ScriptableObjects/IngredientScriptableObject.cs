using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IngredientScriptableObject", order = 2)]
public class IngredientScriptableObject : ScriptableObject
{
    public IngredientId id;
    public Sprite sprite;



    public override string ToString()
    {
        return base.ToString() + "\n"
            + "{" + "\n\t"
            + "id: " + this.id.ToString()
            + "}";
    }
}
