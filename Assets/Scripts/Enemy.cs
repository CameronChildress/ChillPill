using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 10)]
    public float speed = 5;

    [Range(0, 20)]
    public float acceleration = 5;

    private Vector3 velocity;

    public Transform targetTransform;

    public void Update()
    {
        transform.LookAt(targetTransform);

        velocity += transform.forward * acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }


}
