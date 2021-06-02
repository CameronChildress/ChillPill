using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
            //health -= 10;
        }

        Explosion explosion = collision.gameObject.GetComponent<Explosion>();
        if (explosion != null)
        {
            //health -= 10;
        }
    }
}
