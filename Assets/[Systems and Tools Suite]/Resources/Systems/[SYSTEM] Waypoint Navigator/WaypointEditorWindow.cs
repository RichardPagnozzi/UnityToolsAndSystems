using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointEditorWindow : EditorWindow
{
    string waypointName = "";
    public enum ROUTE { RED, YELLOW, BLUE, GREEN, WHITE, TRUCK_A, TRUCK_B }
    public ROUTE VehicleRoute;

    [MenuItem("UTS/WayPoint Window")]
    public static void OpenWindow()
    {
        GetWindow<WaypointEditorWindow>();
    }

    public Transform WaypointRoot;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("WaypointRoot"));


        if (WaypointRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected. Assign a root", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        waypointName = EditorGUI.TextField(new Rect(10, 100, position.width - 20, 20),"WAYPOINT NAME HERE",waypointName);
        VehicleRoute = (ROUTE)EditorGUILayout.EnumPopup("Specified Vehicle Route:", VehicleRoute);


        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
    }

    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject(waypointName + " " + WaypointRoot.childCount, typeof(Wapoint));
        
        waypointObject.transform.SetParent(WaypointRoot, false);

        Wapoint waypoint = waypointObject.GetComponent<Wapoint>();
        SetWaypointColor(waypoint);

        if (WaypointRoot.childCount > 1)
        {
            waypoint.m_previousWaypoint = WaypointRoot.GetChild(WaypointRoot.childCount - 2).GetComponent<Wapoint>();
            waypoint.m_previousWaypoint.m_nextWaypoint = waypoint;
            // placing waypoint at the last position
            waypoint.transform.position = waypoint.m_previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.m_previousWaypoint.transform.forward;
        }

        Selection.activeObject = waypoint.gameObject;

    }


    void SetWaypointColor(Wapoint waypoint)
    {
        switch (VehicleRoute)
        {
            case WaypointEditorWindow.ROUTE.RED:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.RED;
                    break;
                }
            case WaypointEditorWindow.ROUTE.GREEN:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.GREEN;
                    break;
                }
            case WaypointEditorWindow.ROUTE.BLUE:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.BLUE;
                    break;
                }
            case WaypointEditorWindow.ROUTE.YELLOW:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.YELLOW;
                    break;
                }
            case WaypointEditorWindow.ROUTE.WHITE:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.WHITE;
                    break;
                }
            case WaypointEditorWindow.ROUTE.TRUCK_A:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.TRUCK_A;
                    break;
                }
            case WaypointEditorWindow.ROUTE.TRUCK_B:
                {
                    waypoint.VehicleRoute = Wapoint.ROUTE.TRUCK_B;
                    break;
                }
        }
    }
}
