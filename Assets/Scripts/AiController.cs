using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(NavMeshAgent))]

public class AiController : MonoBehaviour
{
    public NavMeshAgent agent;
    private LineRenderer myLineRender;
    public GameObject agentMesh;
    public GameObject test;

    public Transform start;
    public Transform target; 
    CapsuleCollider capsule;

    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;

    void Start()
    {
        test.SetActive(false);
        agent.tag = "blocked";

        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomNavMeshLocation());
        }

        //Line
        myLineRender = GetComponent<LineRenderer>();
        myLineRender.startWidth = 0.1f;
        myLineRender.endWidth = 0.1f;
        myLineRender.positionCount = 0;

        //colider
        //capsule = gameObject.AddComponent(typeof(CapsuleCollider));
        capsule.radius = 0.5f;
        capsule.center = Vector3.zero;
        capsule.direction = 2; // Z-axis for easier "LookAt" orientation

        /*
        myLineRender.startColor = Color.black;
        myLineRender.endColor = Color.white;\
        */



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

    // Update is called once per frame
    void Update()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLocation());
        }
        DrawPath();
        GenerateMeshCollider();

        capsule.transform.position = start.position + (target.position - start.position) / 2;
        capsule.transform.LookAt(start.position);
        capsule.height = (target.position - start.position).magnitude;
    }
    
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        Vector3 finalPosition = Vector3.zero;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

    void DrawPath()
    {
        myLineRender.positionCount = agent.path.corners.Length;
        myLineRender.SetPosition(0, transform.position);

        if (agent.path.corners.Length < 2)
        {
            return;
        }

        for (int i =1; i < agent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y, agent.path.corners[i].z);
            myLineRender.SetPosition(i, pointPosition);
        }
    }

    public void GenerateMeshCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();

        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        myLineRender.BakeMesh(mesh);
        collider.sharedMesh = mesh;
        Debug.Log("mesh created");
    }

    private void OnTriggerEnter(Collider block)
    {
        test.SetActive(true);
        Debug.Log("Blocked");
    }

    private void OnTriggerExit(Collider block)
    {
        test.SetActive(false);
        Debug.Log("No collision");
    }
}
