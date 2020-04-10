using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wapoint : MonoBehaviour
{
    [System.Serializable]
    public enum ROUTE { RED, YELLOW, BLUE, GREEN, WHITE, TRUCK_A, TRUCK_B }
    public ROUTE VehicleRoute; 
    [Space(5)]

    public Wapoint m_previousWaypoint;
    public Wapoint m_nextWaypoint;
}
