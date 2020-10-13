using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UTS
{
    public class MovePosition : MonoBehaviour
    {
        public VirtualJoystick virtualJoystick;
        [SerializeField]
        private float speed;
        [SerializeField]
        private Rigidbody rb;
        [SerializeField, Space(2)]
        private bool canMove;

        // Start is called before the first frame update
        void Start()
        {
            if (!rb)
                rb = this.GetComponent<Rigidbody>();
            speed = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (canMove)
            {
                if (virtualJoystick)
                    MoveToPosition(virtualJoystick.GetInputVector());
            }
        }

        private void MoveToPosition(Vector3 pos)
        {
            this.transform.Translate(pos);
        }
    }
}