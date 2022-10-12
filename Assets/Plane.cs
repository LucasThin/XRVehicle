using UnityEngine;

namespace Assets
{
    public class Plane : MonoBehaviour {

        public GameObject ObjectToEnable;

        public Plane(GameObject objectToEnable)
        {
            ObjectToEnable = objectToEnable;
        }

        void Start () {
            ObjectToEnable.SetActive (false);        
        }

        void OnTriggerEnter(Collider other) { 
            ObjectToEnable.SetActive (true);
    
        }

        void OnTriggerExit(Collider other) {
            ObjectToEnable.SetActive (false);

        }

        
    }
}