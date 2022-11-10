using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class blink_script : MonoBehaviour
{
    public Light light_;
    private GameObject WarningLight;
    SerialPort portNo = new SerialPort("COM4",9600);
    public bool isLight=false;

    public float ftime;
    //step time
    public float stepTime = 0.2f;
    
    void Start()
    {
        portNo.Open();
        portNo.ReadTimeout = 5000;
    }

    void Update()
    {
        //Debug.Log(portNo.ReadByte());
        //light_.enabled = isLight;

        ftime += Time.deltaTime;

        if(ftime >= stepTime)
        {
            if (portNo.IsOpen)
            {
                //Debug.Log("open");
                try
                {
                    blink_light(portNo.ReadByte());

                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            ftime = 0f;
        }

    }

    void blink_light(int stat)
    {
        if (stat == 1)
        {
            light_.enabled = true;
            Debug.Log("light is ON");
            //print(1);
        }
        else 
        {
            light_.enabled = false;
            Debug.Log("light is OFF");
            //print(2);
        }
    }
}