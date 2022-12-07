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

    public GameObject[] pointsOfInterest;
    public int currentPointOfInterest;
    private void Awake()
    {
        triangulation = NavMesh.CalculateTriangulation();
        player = GameObject.FindGameObjectWithTag("Player");
        orderSubmitter = GameObject.Find("OrderSubmitter");
        lineRenderer = FindObjectOfType<LineRenderer>();
        currentPointOfInterest = 0;
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
        if (currentPointOfInterest < pointsOfInterest.Length)
        {
            if (NavMesh.CalculatePath(player.transform.position, pointsOfInterest[currentPointOfInterest].transform.position, NavMesh.AllAreas, path))
            {
                lineRenderer.positionCount = path.corners.Length;

                for (int i = 0; i < lineRenderer.positionCount; i++)
                {
                    lineRenderer.SetPosition(i, path.corners[i] + Vector3.up * pathHeightOffset);
                }
            }
        }

    }

    public void IncrementPointsOfInterestId()
    {
        if (currentPointOfInterest + 1 >= pointsOfInterest.Length)
        {
            lineRenderer.enabled = false;
            currentPointOfInterest += 1;
        } else
        {
            currentPointOfInterest += 1;
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
