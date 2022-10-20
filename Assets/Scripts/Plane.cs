using UnityEngine;

namespace Assets
{
    public class Plane : MonoBehaviour {

        public GameObject planeModel;

        public Plane(GameObject objectToEnable)
        {
            planeModel = objectToEnable;
        }

        void Start () {
            planeModel.SetActive (false);        
        }

        void OnTriggerEnter(Collider other) { 
            planeModel.SetActive (true);
            Debug.Log("Plane mode!");
    
        }

        void OnTriggerExit(Collider other) {
            planeModel.SetActive (false);
            Debug.Log("Plane mode exit!");

        }

        
    }
}