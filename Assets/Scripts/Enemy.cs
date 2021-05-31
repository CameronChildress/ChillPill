using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 15)]
    public float speed = 10;

    [Range(0, 20)]
    public float acceleration = 5;

    private Vector3 velocity;

    public Transform targetTransform;

    public GameObject deathFX;

    public void Update()
    {
        transform.LookAt(targetTransform);

        velocity += transform.forward * acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, speed);
        transform.position += velocity * Time.deltaTime;
    }

    public void KillEnemy()
    {
        //Create FX object
        if (deathFX != null) { Instantiate(deathFX, transform.position, Quaternion.identity); }

        //Remove reference of self from Game object
        Game.Instance.RemoveEnemy(gameObject);

        //Destroy self
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerWeapon"))
        {
            KillEnemy();
        }
    }
}
