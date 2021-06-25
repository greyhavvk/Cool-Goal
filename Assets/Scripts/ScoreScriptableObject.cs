using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Score")]

public class ScoreScriptableObject : ScriptableObject
{
    public int currentScore = 0;
}
