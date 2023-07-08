using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ToolScriptableObject", order = 3)]
public class ToolScriptableObject : ScriptableObject
{
    public ToolId id;
    public Sprite sprite;



    public override string ToString()
    {
        return base.ToString() + "\n"
            + "{" + "\n\t"
            + "id: " + this.id.ToString()
            + "}";
    }
}
