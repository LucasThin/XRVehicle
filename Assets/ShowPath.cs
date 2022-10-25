using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]

public class ShowPath : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject test;
    private LineRenderer myLineRender;
    private MeshCollider linecollider;

    public Transform agentParent;


    // Start is called before the first frame update
    void Start()
    {
        test.SetActive(false);

        //Line
        myLineRender = GetComponent<LineRenderer>();
        myLineRender.startWidth = 0.1f;
        myLineRender.endWidth = 0.1f;
        myLineRender.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myLineRender.transform.SetParent(transform);
        //linecollider.transform.SetParent(transform);
        DrawPath();
        GenerateMeshCollider();
    }

    void DrawPath()
    {
        myLineRender.positionCount = agent.path.corners.Length;
        myLineRender.SetPosition(0, transform.position);

        if (agent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 1; i < agent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y, agent.path.corners[i].z);
            myLineRender.SetPosition(i, pointPosition);
        }

        myLineRender.transform.SetParent(agentParent);
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
        linecollider.transform.SetParent(agentParent);


    }

    private void OnTriggerEnter(Collider other)
    {
        test.SetActive(true);
        myLineRender.startWidth = 1f;
        myLineRender.endWidth = 1f;
        Debug.Log("Blocked");


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
        test.SetActive(false);
        myLineRender.startWidth = 0.1f;
        myLineRender.endWidth = 0.1f;
        Debug.Log("No collision");
    }
}
