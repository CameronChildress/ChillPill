using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Range(1, 100)] public float speed = 10.0f;
    public bool destroyOnHit = false;
    public GameObject destroyFX;

    private void OnDestroy()
    {
        if (destroyFX != null)
        {
            Instantiate(destroyFX, transform.position, transform.rotation);
        }
    }

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Camera.main.transform.forward * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
