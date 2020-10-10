using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCaster : MonoBehaviour
{
    #region Fields
    [SerializeField, Tooltip("Decide whether a raycast should to be fired or not")]
    private bool shouldCast;

    [SerializeField, Tooltip("The position on the grid returned by the raycast. Will return (0,0,0) if not on an available position")]
    Vector3 hitPosition;

    [SerializeField , Tooltip("the layer the raycast should hit")]
    private int layerMask;
    
    [SerializeField, Tooltip("If the raycast hit position returned is on the designated layer")]
    private bool onAvailableLayer;

    [SerializeField, Tooltip("The Grid Object the raycast is hitting OR not hitting")]
    private GameObject hitObject;

    [SerializeField, Tooltip("The Object from which the raycast should be fired from")]
    private GameObject raycastObject;


    private RaycastHit raycastHit;
    private bool hitTargetObject { get; set; }
    #endregion

    #region Monobehaviours
    private void Awake()
    {
        onAvailableLayer = false;
        shouldCast = false;
        hitTargetObject = false;
        
        if (layerMask == null)
            layerMask = 0;

        if (raycastObject == null)
            raycastObject = this.gameObject;
    }



    private void Update()
    {
        if (shouldCast)      
            hitObject = RaycastFromCamera();
        
        if (hitTargetObject) 
            onAvailableLayer = true;       
        else 
            onAvailableLayer = false;
    }
    #endregion

    #region Methods
    // private Methods
    private GameObject RaycastFromCamera()
    {
        if (Physics.Raycast(raycastObject.transform.position, raycastObject.transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity))
        {
            if (raycastHit.transform.gameObject.layer == layerMask)
            {
                Debug.DrawRay(raycastObject.transform.position, raycastObject.transform.TransformDirection(Vector3.forward) * raycastHit.distance, Color.green);
                hitTargetObject = true;
            }
            else
            {
                Debug.DrawRay(raycastObject.transform.position, raycastObject.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                hitTargetObject = false;
            }

            hitPosition = raycastHit.point;
            return raycastHit.transform.gameObject;
        }
        return null;

    }

    // Public Methods
    public Vector3 GetHitPosition()
    {
        hitPosition = new Vector3(hitPosition.x, 0, hitPosition.z);
        return hitPosition;
    }

    public GameObject GetObjectAtHitPosition() { return hitObject; }
    public void EnableCasting() { shouldCast = true; }
    public void DisableCasting() { shouldCast = false; }
    public bool GetAvailablity() { return onAvailableLayer; }

    #endregion
}
