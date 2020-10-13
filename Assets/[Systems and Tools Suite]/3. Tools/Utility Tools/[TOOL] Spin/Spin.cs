using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTS
{
    public class Spin : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10f;
        [SerializeField]
        private bool SpinRight = true;

        void Update()
        {
            if (SpinRight)
                transform.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime);
            else
                transform.Rotate(new Vector3(0, 0, -1), speed * Time.deltaTime);
        }
    }
}