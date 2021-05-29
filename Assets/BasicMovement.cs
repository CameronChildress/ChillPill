using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
    }
}
