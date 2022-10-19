using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject WarningLight;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        WarningLight.SetActive(true);
        Debug.Log("Alert Person Entered Idle Person's Zone");
    }

    void OnTriggerExit(Collider other)
    {
        WarningLight.SetActive(false);
    }
}
