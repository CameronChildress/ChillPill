using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    [Range(0, 10)]
    public float speed = 5;
    private float defaultSpeed;

    public float shotFireSpeed = 4;
    private float currentFireTime = 0;
    public float shotAirTime = 3;

/*    [Range(0, 20)]
    public float acceleration = 5;*/

    private Vector3 velocity;

    public Transform targetTransform;
    public Transform shotTransform;


    public GameObject projectile;
    public GameObject deathFX;
    public GameObject debugMarker;
    public GameObject follower;

    public List<WeakSpot> weakSpots = new List<WeakSpot>();

    public void Awake()
    {
        defaultSpeed = speed;
        foreach (WeakSpot weak in weakSpots)
        {
            weak.SetDragonParent(this);
        }
    }

    public void Start()
    {
        GameObject newObject = Instantiate(follower, Vector3.zero, Quaternion.identity);

        float randAngle = Random.Range(0, 360);
        newObject.transform.position += new Vector3(24, 10, 0) + Player.Instance.transform.position;

        newObject.transform.RotateAround(targetTransform.position, Vector3.up, randAngle);
        targetTransform = newObject.transform;
    }

    void Update()
    {
        if (weakSpots.Count <= 0) KillEnemy();
        FireUpdate();
        speed = (Vector3.Distance(targetTransform.position, transform.position) > 30) ? defaultSpeed * 3 : defaultSpeed;

        Quaternion neededRotation = Quaternion.LookRotation(targetTransform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 40f);


        velocity += transform.forward * speed * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, speed);
        transform.position += velocity * Time.deltaTime;
    }

    private void FireUpdate()
    {
        currentFireTime += Time.deltaTime;

        if (currentFireTime >= shotFireSpeed)
        {
            currentFireTime -= shotFireSpeed;
            Shoot();
        }
    }

    public void KillEnemy()
    {
        //Create FX object
        if (deathFX != null) { Instantiate(deathFX, transform.position, Quaternion.identity); }

        //Remove reference of self from Game object
        Game.Instance.RemoveEnemy(gameObject);

        //Spawn gems
        SpawnGems();

        //Destroy self
        Destroy(this.gameObject);
    }

    public void SpawnGems()
    {
        int randGems = Random.Range(4,8);

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

    private void Shoot()
    {
        float yVelocity = (-(transform.position.y) - 0.5f * (-9.8f) * (shotAirTime * shotAirTime)) / shotAirTime;

        Vector3 guessedPosition = (Player.Instance.transform.position) + (Player.Instance.movement.velocity * shotAirTime);
        guessedPosition.y = shotTransform.position.y;
        //Instantiate(debugMarker, new Vector3 (guessedPosition.x, 0, guessedPosition.z) , Quaternion.identity);
        Vector3 vMagnitude = (guessedPosition - shotTransform.position) / shotAirTime;
        vMagnitude.y = yVelocity;

        //Create object and add velocity
        GameObject shot = Instantiate(projectile, shotTransform.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().AddForce(vMagnitude, ForceMode.VelocityChange);
    }
}
