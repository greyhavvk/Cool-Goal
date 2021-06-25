using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class LevelScriptableObject : ScriptableObject
{
    public int currentLevel = 0;
}
