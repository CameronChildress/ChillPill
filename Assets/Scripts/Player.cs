using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100.0f;
    private static Player instance;
    public static Player Instance { get { return instance; } }
    public BasicMovement movement;
    public Weapon weapon;
    public CharacterController characterController;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnFire();
        }

        if (health <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void OnFire()
    {
        weapon.Fire(transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            health -= 10;
        }
    }
}
