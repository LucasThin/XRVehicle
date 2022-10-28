using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]

public class ShowPath : MonoBehaviour
{
    public NavMeshAgent agent;
    public LineRenderer myLineRender;

    //private MeshCollider linecollider;

    public Transform agentParent;

    // Start is called before the first frame update
    void Start()
    {

        //Line
        myLineRender = GetComponent<LineRenderer>();
        myLineRender.startWidth = 0.1f;
        myLineRender.endWidth = 0.1f;
        myLineRender.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DrawPath();
        //GenerateMeshCollider();
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

    }

    /*public void GenerateMeshCollider()
    {
        linecollider = GetComponent<MeshCollider>();

        if (linecollider == null)
        {
            linecollider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        myLineRender.BakeMesh(mesh,true);
        linecollider.sharedMesh = mesh;
    }*/

}
