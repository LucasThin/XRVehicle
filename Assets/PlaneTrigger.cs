using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour {

    public GameObject planeTrigger;
    public GameObject planeModel;
    private bool ifCollision;
    private bool ifPlaneMode;

    void Start () {
        planeTrigger.SetActive (false);
        gameObject.tag = "Collision";
    }

    private void Update()
    {
        /* if (IfCollision == true)
        {
            planeModel.SetActive(true);
        }
        else
        {
            planeModel.SetActive(false);
        }*/
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collision"))
        {
            planeTrigger.SetActive (true);
            ifCollision = true;
            Debug.Log("Collision Triggered!");
        }
        if (other.CompareTag("PlaneTrigger"))
        {
            planeModel.SetActive (true);
            ifPlaneMode = true;
            Debug.Log("Plane Mode Triggered!");
        }



    }

    void OnTriggerExit(Collider other) {
        planeTrigger.SetActive (false);
        ifCollision = true;

    }

        
}