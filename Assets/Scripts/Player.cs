using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 50.0f;
    private static Player instance;

    public float score = 0;
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

        Explosion explosion = collision.gameObject.GetComponent<Explosion>();
        if (explosion != null)
        {
            health -= 10;
        }

        if (collision.collider.CompareTag("Gem"))
        {
            health = Mathf.Min(health+1, 50);
            score += 30;
            Instantiate(PrefabManager.Instance.GetPrefab("GemSound"), transform.position, Quaternion.identity);
            Destroy(collision.collider.gameObject);
        }
    }
}
