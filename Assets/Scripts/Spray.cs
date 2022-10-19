using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray: MonoBehaviour
{

    private GameObject SprayEffect;

    void Start()
    {
        SprayEffect.SetActive(true);
        Debug.Log("Person Entered Alert Zone");
    }

    void OnTriggerEnter(Collider other)
    {
        SprayEffect.SetActive(false);

    }


}
