using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public int levelNumber;

    public GoalController goal;
    public BallController ball;

	// Use this for initialization
	void Start () {
        goal.SetLevel(levelNumber); // set the goals level so it can only be completed by its levels ball
        ball.SetLevel(levelNumber);	//set the ball's level so it can only complete its level
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
