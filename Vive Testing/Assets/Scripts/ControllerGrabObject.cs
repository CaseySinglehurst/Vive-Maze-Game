using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

 
    private GameObject collidingObject; // object currently in the controller's grab zone
    private GameObject objectInHand; // object currently picked up by controller

    public Transform grabbedObjectTarget; // ideal transform of an object in hand

    public float grabbedObjectMoveSpeed; // how fast object moves to grabbedObjectTarget

    public GameController gc;

    Quaternion OriginalRotation;
    Quaternion InverseParentRotation;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        
    }

    private void SetCollidingObject(Collider col)
    {
        
        if (collidingObject || !col.GetComponent<Rigidbody>() || col.gameObject.layer != LayerMask.NameToLayer("MazeRigidBody"))
        {
            return;
        }
        
        collidingObject = col.gameObject;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        objectInHand.GetComponent<Rigidbody>().angularVelocity  = new Vector3(0, 0, 0);
        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        grabbedObjectTarget.SetPositionAndRotation(objectInHand.transform.position, objectInHand.transform.rotation);


    }
    
    //Not currently in use (better method found)
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        
        fx.breakForce = 2000;
        fx.breakTorque = 2000;
        return fx;
    }

    //released object from grip, with the controllers velocity and angular velocity
    private void ReleaseObject()
    {
        objectInHand.GetComponent<Rigidbody>().velocity += Controller.velocity;
        objectInHand.GetComponent<Rigidbody>().angularVelocity += Controller.angularVelocity;
        objectInHand.GetComponent<Rigidbody>().useGravity = true;
        objectInHand = null;

    }

    

    // Update is called once per frame
    void Update () {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }
        
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            gc.SpawnCurrentLevel();
        }
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            gc.CleanUpLevels();
        }


        if(objectInHand != null)
        {
           objectInHand.transform.position =  Vector3.Lerp(objectInHand.transform.position, grabbedObjectTarget.position, grabbedObjectMoveSpeed * Time.deltaTime);
            objectInHand.transform.rotation = Quaternion.Lerp(objectInHand.transform.rotation, grabbedObjectTarget.rotation, grabbedObjectMoveSpeed * Time.deltaTime);
        }

    }
}
