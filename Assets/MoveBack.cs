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
        //Debug.Log(transform.position);

        /* if ( 0 <= previousRotation &&  previousRotation <= 180)
        {
            if (transform.forward.x>0 && transform.forward.z>0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward");
            }
            else if (transform.forward.x<0 && transform.forward.z<0)
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
        }*/
        
        if (transform.forward.x>0 && transform.forward.z>0)
        {
            if (currentX - lastX > 0 && currentZ - lastZ > 0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward:0-90");
            }
            else if (currentX - lastX < 0 && currentZ - lastZ < 0)
            {
                frontCamera.SetActive(false);
                backCamera.SetActive(true);
                Debug.Log("Go backward:0-90");
            }
        }
        else if (transform.forward.x>0 && transform.forward.z<0)
        {
            if (currentX - lastX > 0 && currentZ - lastZ < 0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward:90-180");
            }
            else if (currentX - lastX < 0 && currentZ - lastZ > 0)
            {
                frontCamera.SetActive(false);
                backCamera.SetActive(true);
                Debug.Log("Go backward:90-180");
            }
        }
        else if (transform.forward.x<0 && transform.forward.z<0)
        {
            if (currentX - lastX < 0 && currentZ - lastZ < 0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward:-90-0");
            }
            else if (currentX - lastX > 0 && currentZ - lastZ > 0)
            {
                frontCamera.SetActive(false);
                backCamera.SetActive(true);
                Debug.Log("Go backward:-90-0");
            }
        }
        else if (transform.forward.x<0 && transform.forward.z>0)
        {
            if (currentX - lastX < 0 && currentZ - lastZ > 0)
            {
                frontCamera.SetActive(true);
                backCamera.SetActive(false);
                Debug.Log("Go forward:-180 - -90");
            }
            else if (currentX - lastX > 0 && currentZ - lastZ < 0)
            {
                frontCamera.SetActive(false);
                backCamera.SetActive(true);
                Debug.Log("Go backward:-180 - -90");
            }
        }
        
        /*if (transform.forward.x>0 && transform.forward.z>0)
        {
            frontCamera.SetActive(true);
            backCamera.SetActive(false);
            Debug.Log("Go forward");
        }
        else if (transform.forward.x<0 && transform.forward.z<0)
        {
            frontCamera.SetActive(false);
            backCamera.SetActive(true);
            Debug.Log("Go backward");
        }*/

        lastX = currentX;
        lastZ = currentZ;

    }
}
