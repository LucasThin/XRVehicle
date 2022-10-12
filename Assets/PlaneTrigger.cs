using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour {

    public GameObject ObjectToEnable;

    void Start () {
        ObjectToEnable.SetActive (false);        
    }

    void OnTriggerEnter(Collider other) { 
        ObjectToEnable.SetActive (true);
    
    }

    void OnTriggerExit(Collider other) {
        ObjectToEnable.SetActive (false);

    }

        
}