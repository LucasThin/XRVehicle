using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMode : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Test;
    public GameObject CarModeTrigger;
    public GameObject Camera;
    public GameObject Height;
    bool IfCarMode;

    //public float CarModeTriggerHeight;
    public Vector3 cameraOffset = new Vector3 (0f, -0.9f, 0f);

    void Awake()
    {
        Height.transform.position = new Vector3 (0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        CarModeTrigger.transform.position = new Vector3(Camera.transform.position.x, 0f, Camera.transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        Test.SetActive(true);
        Height.transform.position = cameraOffset;
    }

    private void OnTriggerExit(Collider other)
    {
        Test.SetActive(false);
    }
}
