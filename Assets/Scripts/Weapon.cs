using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Range(0, 3)] public float fireRate = 0.1f;
    [Range(0, 100)] public float angle = 10.0f;

    int ammo = 100;
    float fireTimer = 0;

    public GameObject projectile;
    public Transform emitTransform;

    void Start()
    {

    }

    void Update()
    {
        fireTimer += Time.deltaTime;
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;

            GameObject gameObject = Instantiate(projectile, position, Quaternion.identity);
            gameObject.GetComponent<Projectile>().Fire(direction);

            Destroy(gameObject, 3);

            return true;
        }

        return false;
    }

    public bool Fire(Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;

            GameObject gameObject = Instantiate(projectile, emitTransform.position, emitTransform.rotation);
            gameObject.GetComponent<Projectile>().Fire(direction);

            Destroy(gameObject, 3);

            return true;
        }

        return false;
    }
}
