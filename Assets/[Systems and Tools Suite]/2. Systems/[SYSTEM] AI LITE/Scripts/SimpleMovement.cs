using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private float moveSpeed = 50;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.forward;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.back;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction += Vector3.right;

        transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime), Space.World);
    }
}
