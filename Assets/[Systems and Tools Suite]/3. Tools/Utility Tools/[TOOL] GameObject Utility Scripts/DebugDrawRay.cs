using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.localPosition, forward, Color.green);
    }


    private void OnDrawGizmos()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
