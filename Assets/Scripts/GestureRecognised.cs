using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognised : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    // Start is called before the first frame update
    public void OnGestureCompleted(GestureCompletionData gestureCompletionData)
    {
        if (gestureCompletionData.gestureID < 0)
        {
            string errorMessage = GestureRecognition.getErrorMessage(gestureCompletionData.gestureID);
            return;
        }
        if (gestureCompletionData.similarity >= 0.5)
        {
            _object.SetActive(true);
        }
    }
}
