using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 playerForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            playerForward = playerForward.normalized;

            float speed = 5.0f;
            transform.position += playerForward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 playerBack = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            playerBack = -playerBack.normalized;

            float speed = 5.0f;
            transform.position += playerBack * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 playerForward = new Vector3(-Camera.main.transform.forward.x, 0, 0);
            playerForward = playerForward.normalized;

            float speed = 5.0f;
            transform.position += playerForward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 playerForward = new Vector3(Camera.main.transform.forward.x, 0, 0);
            playerForward = playerForward.normalized;

            float speed = 5.0f;
            transform.position += playerForward * speed * Time.deltaTime;
        }
    }
}
