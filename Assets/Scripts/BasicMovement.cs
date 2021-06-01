using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5;

    public Vector3 velocity;

    void Update()
    {
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 playerForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            playerForward = playerForward.normalized;

            velocity = playerForward * speed;
            transform.position += velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 playerBack = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            playerBack = -playerBack.normalized;

            velocity = playerBack * speed;
            transform.position += velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 playerLeft = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            playerLeft = playerLeft.normalized;

            Vector2 v2 = new Vector2(Camera.main.transform.forward.x, Camera.main.transform.forward.z);
            v2 = Vector2.Perpendicular(v2).normalized;

            Vector3 v3 = new Vector3(v2.x, 0, v2.y);

            velocity = v3 * speed;
            transform.position += velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 playerLeft = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            playerLeft = playerLeft.normalized;

            Vector2 v2 = new Vector2(Camera.main.transform.forward.x, Camera.main.transform.forward.z);
            v2 = Vector2.Perpendicular(v2).normalized;

            Vector3 v3 = new Vector3(v2.x, 0, v2.y);

            velocity = -v3 * speed;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
