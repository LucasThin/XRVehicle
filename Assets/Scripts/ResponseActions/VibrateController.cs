﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Vibrate the XR Controller
/// </summary>
public class VibrateController : MonoBehaviour
{
    public float strongVibrate = 0.75f;
    public float weakVibrate = 0.25f;

    
    public XRController controller = null;

    private void Awake()
    {
        // Use te code below instead if you put this script on GameObjects that are not controllers
       // controller = (XRController)GameObject.FindObjectOfType(typeof(XRController));
       //Use script below onnly if you put this on GameObjects that are controllers
       controller = GetComponent<XRController>();
    }

    public void Vibrate(float amplitude, float duration)
    {
        // OpenVR currently only supports amplitude
        controller.SendHapticImpulse(amplitude, duration);
    }

    public void VibrateWeak(float duration)
    {
        controller.SendHapticImpulse(weakVibrate, duration);
    }

    public void VibrateStrong(float duration)
    {
        controller.SendHapticImpulse(strongVibrate, duration);
    }
}
