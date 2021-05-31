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

    [Range(0, 20)]
    public float acceleration = 5;

    private Vector3 velocity;

    public Transform targetTransform;

    public GameObject projectile;
    public GameObject deathFX;
    public GameObject debugMarker;

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
        FireUpdate();
        speed = (Vector3.Distance(targetTransform.position, transform.position) > 30) ? defaultSpeed * 3 : defaultSpeed;

        Quaternion neededRotation = Quaternion.LookRotation(targetTransform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 25f);

        velocity += transform.forward * acceleration * Time.deltaTime;
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

        //Destroy self
        Destroy(this.gameObject);
    }

    private void Shoot()
    {
        Vector3 playerVelocity = Player.Instance.characterController.velocity;
        float yVelocity = (-(transform.position.y) - 0.5f * (-9.8f) * (shotAirTime * shotAirTime)) / shotAirTime;

        Vector3 guessedPosition = (Player.Instance.transform.position) + (Player.Instance.movement.velocity * shotAirTime);
        guessedPosition.y = transform.position.y;
        Instantiate(debugMarker, new Vector3 (guessedPosition.x, 0, guessedPosition.z) , Quaternion.identity);
        Vector3 vMagnitude = (guessedPosition - transform.position) / shotAirTime;
        vMagnitude.y = yVelocity;

        //Create object and add velocity
        GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().AddForce(vMagnitude, ForceMode.VelocityChange);
    }
}
