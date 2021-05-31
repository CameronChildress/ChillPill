using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    [Range(0, 10)]
    public float speed = 5;

    [Range(0, 20)]
    public float acceleration = 5;

    private Vector3 velocity;

    public Transform targetTransform;

    public GameObject deathFX;

    public List<WeakSpot> weakSpots = new List<WeakSpot>();

    public void Awake()
    {
        foreach (WeakSpot weak in weakSpots)
        {
            weak.SetDragonParent(this);
        }
    }

    public void Start()
    {
        GameObject newObject = new GameObject();
        newObject.transform.parent = targetTransform;

        float randAngle = Random.Range(0, 360);
        newObject.transform.position += new Vector3(24, 10, 0);

        newObject.transform.RotateAround(targetTransform.position, Vector3.up, randAngle);
        targetTransform = newObject.transform;
    }

    void Update()
    {
        if (weakSpots.Count <= 0) KillEnemy();

        Quaternion neededRotation = Quaternion.LookRotation(targetTransform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 25f);

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
}
