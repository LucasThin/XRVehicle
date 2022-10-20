using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {

    public GameObject planeTrigger;
    public GameObject carModeTrigger;
    public GameObject planeModel;

    void Start () {
        planeTrigger.SetActive (false);
        carModeTrigger.SetActive (false);
        planeModel.SetActive (false);
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

    void OnTriggerEnter(Collider other)
    {
        planeTrigger.SetActive(true);
        carModeTrigger.SetActive(true);
        Debug.Log("Trigger zone activated!");

    }

    void OnTriggerExit(Collider other) {
        planeTrigger.SetActive (false);
        planeTrigger.SetActive (false);
        planeModel.SetActive (false);

    }

        
}