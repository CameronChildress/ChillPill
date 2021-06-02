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

        //spawn gems
        SpawnGems();

        //Destroy self
        Destroy(this.gameObject);
    }

    public void SpawnGems()
    {
        int randGems = Random.Range(1, 3);

        for (int i = 0; i < randGems; i++)
        {
            SpawnGem();
        }
    }
    
    public void SpawnGem()
    {
        string randGem = "Gem" + Random.Range(1, 3);
        GameObject gem = Instantiate(PrefabManager.Instance.GetPrefab(randGem), transform.position, Quaternion.identity);
        Rigidbody rb = gem.GetComponent<Rigidbody>();

        float forceMagnitude = Random.Range(2.5f, 7.0f);
        Vector3 forceDirection = new Vector3(Random.Range(-1.0f, 1.0f), 1, Random.Range(-1.0f, 1.0f)).normalized;

        rb.AddForce(forceDirection * forceMagnitude, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerWeapon"))
        {
            KillEnemy();
        }
    }
}
