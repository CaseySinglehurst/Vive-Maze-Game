using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{

    public GameObject mazeRigidController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

        /*
         * Maze has a seperate, non interacting collider which links with the rigid body to determine how its physics should work
         * This is because the maze needs a complicated collider for the ball to interact with, which cannot be used by the in build rigid body physics
         * This update method sets the position and rotation of the maze to its (invisible) physics controlled collider, mimicing physics interactions
         * while ensuring the ball can still use the complicated mesh collider
         */
    void Update()
    {
        //match the transform of the controller
        transform.SetPositionAndRotation(mazeRigidController.transform.position, mazeRigidController.transform.rotation);
    }
}
