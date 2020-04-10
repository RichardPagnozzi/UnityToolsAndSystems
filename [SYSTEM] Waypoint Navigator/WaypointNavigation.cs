using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointNavigation : MonoBehaviour
{
    #region Variables
    public GameObject WaypointRoot;
    public List<Transform> waypoints;
    [SerializeField]
    public int nextPosition = 0;
    private NavMeshAgent agent;
    #endregion 

    #region Factory Methods
    private void OnDrawGizmos()
    {
        if (WaypointRoot && waypoints.Count == 0)
        {
            foreach (Transform child in WaypointRoot.transform)
            {
                waypoints.Add(child.transform);
            }
        }           
    }
    void Start()
    {
        if (WaypointRoot && waypoints.Count == 0)
        {
            foreach (Transform child in WaypointRoot.transform)
            {
                waypoints.Add(child.transform);
            }
        }
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        agent.SetDestination(waypoints[nextPosition].position);
    }
    #endregion

    void GotoNextPoint()
    {
        if (waypoints.Count == 0)
            return;

        nextPosition = (nextPosition + 1) % waypoints.Count;

        agent.SetDestination(waypoints[nextPosition].position);
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[nextPosition].position) < 6f)
        {
            GotoNextPoint();
        }
    }

}
