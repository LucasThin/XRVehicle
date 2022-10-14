using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    // Start is called before the first frame update\
    private float currentX;
    private float lastX;
    private float currentZ;
    private float lastZ;
    
    private float previousRotation;

    public GameObject frontCamera;
    public GameObject backCamera;
    

    void Start()
    {
        frontCamera.SetActive(true);
        backCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        previousRotation = transform.rotation.y;
        currentX = transform.position.x;
        currentZ = transform.position.z;


        if ( 1 <= previousRotation &&  previousRotation <= 179)
        {
            if (currentX - lastX > 0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward");
            }
            else
            {
                frontCamera.SetActive(false);
                backCamera.SetActive(true);
                Debug.Log("Go backward");
            }
        }
        else
        {
            if (currentX - lastX < 0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward");
            }
            else
            {
                frontCamera.SetActive(false);
                backCamera.SetActive(true);
                Debug.Log("Go backward");
            }
        }

        lastX = currentX;
        lastZ = currentZ;

    }
}
