using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public Transform target;
    public float magnitude = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 directionVector = (target.transform.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(directionVector * magnitude);
        }
    }
}
