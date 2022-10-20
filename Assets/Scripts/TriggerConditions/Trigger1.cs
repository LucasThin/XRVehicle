using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] private GameObject SprayEffect;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        SprayEffect.SetActive(true);
        Debug.Log("Person Entered Alert Zone");
    }

    void OnTriggerExit(Collider other)
    {
        SprayEffect.SetActive(false);
    }
}
