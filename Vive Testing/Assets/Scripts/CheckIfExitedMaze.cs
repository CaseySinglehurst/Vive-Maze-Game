using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfExitedMaze : MonoBehaviour {

    GameObject waywardBalls;

	// Use this for initialization
	void Start () {

        waywardBalls = GameObject.FindGameObjectWithTag("WaywardBalls");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    // set the ball to not have a parent so it doesnt move with any maze
    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("MazePerimeter"))
        {
            transform.SetParent(waywardBalls.transform);
        }
    }
}
