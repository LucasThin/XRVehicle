using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// Manages the spatial anchors of the project
/// </summary>
public class SpatialAnchorsManager : MonoBehaviour
{   
    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Button pressed");
        }
        bool trigger1Pressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        bool trigger2Pressed = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
 
        //if the user has pressed the index trigger on one of the two controllers, generate an object in that position
        if (trigger1Pressed)
            GenerateObject(true);
 
        if (trigger2Pressed)
            GenerateObject(false);
    }
 
    /// <summary>
    /// Generates an object with the same pose of the controller
    /// </summary>
    /// <param name="isLeft">If the controller to take as reference is the left or right one</param>
    private void GenerateObject(bool isLeft)
    {
        //get the pose of the controller in local tracking coordinates
        OVRPose objectPose = new OVRPose()
        {
            position = OVRInput.GetLocalControllerPosition(isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch),
            orientation = OVRInput.GetLocalControllerRotation(isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch)
        };
 
        //Convert it to world coordinates
        OVRPose worldObjectPose = OVRExtensions.ToWorldSpacePose(objectPose);
 
        //generate an object depending on the controller onto which the trigger was pressed, and assign it the pose of the controller
        GameObject.Instantiate(Resources.Load<GameObject>(isLeft ? "Object1" : "Object2"),
            worldObjectPose.position,
            worldObjectPose.orientation
        );
    }
}