using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialPathRenderer : MonoBehaviour
{
    private float pathUpdateSpeed = 0.25f;
    private GameObject player;
    private GameObject orderSubmitter;
    private float pathHeightOffset = 1.25f;

    private LineRenderer lineRenderer;
    private NavMeshTriangulation triangulation;
    private Coroutine drawPathCoroutine;
    private void Awake()
    {
        triangulation = NavMesh.CalculateTriangulation();
        player = GameObject.FindGameObjectWithTag("Player");
        orderSubmitter = GameObject.Find("OrderSubmitter");
        lineRenderer = FindObjectOfType<LineRenderer>();
    }

    private void Start()
    {
        //if (drawPathCoroutine != null)
        //{
        //    StopCoroutine(drawPathCoroutine);
        //}

        //drawPathCoroutine = StartCoroutine(DrawPathToPointOfInterest());
    }

    private void Update()
    {
        NavMeshPath path = new NavMeshPath();

        if (NavMesh.CalculatePath(player.transform.position, new Vector3(0, 0, 0), NavMesh.AllAreas, path))
        {
            lineRenderer.positionCount = path.corners.Length;

            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetPosition(i, path.corners[i] + Vector3.up * pathHeightOffset);
            }
        }
    }

    //private IEnumerator DrawPathToPointOfInterest()
    //{
    //    WaitForSeconds waitTime = new WaitForSeconds(pathUpdateSpeed);
    //    NavMeshPath path = new NavMeshPath();

    //    if (NavMesh.CalculatePath(player.transform.position, new Vector3(0,0,0), NavMesh.AllAreas, path))
    //    {
    //        lineRenderer.positionCount = path.corners.Length;

    //        for (int i = 0; i < lineRenderer.positionCount;  i++)
    //        {
    //            lineRenderer.SetPosition(i, path.corners[i] + Vector3.up * pathHeightOffset);
    //        }
    //    }

    //    yield return waitTime;
    //}

}
