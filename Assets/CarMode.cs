using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMode : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Test;
    public GameObject CarModeTrigger;
    public GameObject MainCamera;
    public GameObject CarCamera;
    bool IfCarMode;

    //public float CarModeTriggerHeight;
    //public Vector3 cameraOffset = new Vector3 (0f, -0.9f, 0f);

    void Awake()
    {
        MainCamera.SetActive(true);
        CarCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CarModeTrigger.transform.position = new Vector3(MainCamera.transform.position.x, 0.6f, MainCamera.transform.position.z);
        if (IfCarMode == true)
        {
            MainCamera.SetActive(false);
            CarCamera.SetActive(true);
        }
        else
        {
            MainCamera.SetActive(true);
            CarCamera.SetActive(false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        IfCarMode = true;
        Test.SetActive(true);
        Debug.Log("Triggered!");
    }

    private void OnTriggerExit(Collider other)
    {
        IfCarMode = false;
        Test.SetActive(false);
        Debug.Log("Left");
    }
}
