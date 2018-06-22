using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

    int level;

    public void SetLevel(int l)
    {
        level = l;
    }
    public int GetLevel()
    {
        return level;
    }

    //check if ball level mathces goal level
    public bool IsGoalForLevel(int l)
    {
        if (l == level)
        {
            return true;
        }
        return false;
    }

}
