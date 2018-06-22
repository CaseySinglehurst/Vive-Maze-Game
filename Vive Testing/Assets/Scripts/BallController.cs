using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {


    public GameObject goal;
    public GameController gc;
    int level;



	// Use this for initialization
	void Start () {
        
        Physics.IgnoreLayerCollision(8, 10); // ignores collision between ball and maze physics controlling rigid body
        Physics.IgnoreLayerCollision(9, 10); // ignores collision between maze physics controlling rigid body and "real" collising rigid body


        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //if ball is in goal, spawn next level
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            if (other.gameObject.GetComponent<GoalController>().IsGoalForLevel(level) && gc.GetCurrentLevel() == level)
            {
                gc.SpawnNewLevel();
            }
        }
    }

    public void SetLevel(int l)
    {
        level = l;
    }
}
