using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollider : MonoBehaviour
{

    private MeshCollider linecollider;
    public LineRenderer myLineRender;
    public GameObject NavAgent;

    public GameObject test;
    public bool triggerCheck;


    // Start is called before the first frame update
    void Start()
    {
        triggerCheck = false;
        test.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMeshCollider();

        if(triggerCheck == true)
        {
            test.SetActive(true);
            myLineRender.startWidth = 1f;
            myLineRender.endWidth = 1f;
            Debug.Log("Blocked");
        }

        else
        {
            test.SetActive(false);
            myLineRender.startWidth = 0.1f;
            myLineRender.endWidth = 0.1f;
            Debug.Log("No collision");
        }

    }

    public void GenerateMeshCollider()
    {
        linecollider = GetComponent<MeshCollider>();

        if (linecollider == null)
        {
            linecollider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        myLineRender.BakeMesh(mesh, true);
        linecollider.sharedMesh = mesh;

    }

    private void OnTriggerEnter(Collider other)
    {
        triggerCheck = true;


        /*
        //Line Color
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f), }
        );
        myLineRender.colorGradient = gradient;
        */
    }

    private void OnTriggerExit(Collider other)
    {
        triggerCheck = false;
    }

}
