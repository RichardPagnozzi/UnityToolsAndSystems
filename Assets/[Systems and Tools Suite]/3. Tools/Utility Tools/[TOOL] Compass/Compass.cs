using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTS
{
    public class Compass : MonoBehaviour
    {
        [SerializeField]
        private GameObject trackedObject;
        [SerializeField]
        private Vector3 rotation;



        void Update()
        {
            rotation = new Vector3(0, 0, trackedObject.transform.eulerAngles.y);
            transform.rotation = Quaternion.Euler(rotation);

        }
    }
}