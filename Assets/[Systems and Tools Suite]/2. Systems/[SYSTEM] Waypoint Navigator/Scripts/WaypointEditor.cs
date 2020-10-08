using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointEditor : Editor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Wapoint waypoint, GizmoType gizmoType)
    {
        switch (waypoint.VehicleRoute)
        {
            case Wapoint.ROUTE.RED:
                {
                    Gizmos.color = Color.red;
                    break;
                }
            case Wapoint.ROUTE.GREEN:
                {
                    Gizmos.color = Color.green;
                    break;
                }
            case Wapoint.ROUTE.BLUE:
                {
                    Gizmos.color = Color.blue;
                    break;
                }
            case Wapoint.ROUTE.YELLOW:
                {
                    Gizmos.color = Color.yellow;
                    break;
                }
            case Wapoint.ROUTE.WHITE:
                {
                    Gizmos.color = Color.white;
                    break;
                }
            case Wapoint.ROUTE.TRUCK_A:
                {
                    Gizmos.color = Color.cyan;
                    break;
                }
            case Wapoint.ROUTE.TRUCK_B:
                {
                    Gizmos.color = Color.magenta;
                    break;
                }
        }
        if (waypoint.m_nextWaypoint == null || waypoint.m_previousWaypoint == null)
            Gizmos.DrawCube(waypoint.transform.position + new Vector3(0, 2, 0), new Vector3(4,4,4));
        else
            Gizmos.DrawSphere(waypoint.transform.position + new Vector3(0, 2, 0), 2f);
        if (waypoint.m_nextWaypoint)
            Gizmos.DrawLine(waypoint.transform.position, waypoint.m_nextWaypoint.transform.position);
    }
}
