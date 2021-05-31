using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;

    public static Game Instance { get { return instance; } } 

    float score;

    public int initialMaxSpawnNum;
    private int currentSpawnNum;
    public int waveIncreaseThreshold;
    private int enemyKills;

    public float initialSpawnTime;
    private float currentSpawnTime;


    [Range(20,35)]
    public float minSpawnRange;
    [Range(35, 55)]
    public float maxSpawnRange;
    private float currentTime;
    public bool spawnOffScreen;

    public Camera playerCamera;
    public GameObject flyingEnemy;
    public GameObject dragonEnemy;

    private List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        currentSpawnTime = initialSpawnTime;
        currentSpawnNum = initialMaxSpawnNum;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > currentSpawnTime && enemies.Count < currentSpawnNum)
        {
            SpawnFlyingEnemy();
            currentTime -= currentSpawnTime;
            currentSpawnTime *= 0.95f;
        }
    }

    private void SpawnFlyingEnemy()
    {

        Vector2 behindPlayer = new Vector2(playerCamera.transform.forward.x, playerCamera.transform.forward.z) * -1;
        behindPlayer = behindPlayer.normalized;

        float distRange = Random.Range(minSpawnRange, maxSpawnRange);
        float diffRange = Random.Range(-30.0f, 30.0f);

        behindPlayer *= distRange;

        Vector2 perp = Vector2.Perpendicular(behindPlayer).normalized;
        perp *= diffRange;

        behindPlayer += perp;

        Vector3 newPos = new Vector3(playerCamera.transform.position.x + behindPlayer.x, 0.5f, playerCamera.transform.position.z + behindPlayer.y);

        GameObject newEnemy = Instantiate(flyingEnemy, newPos, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().targetTransform = playerCamera.transform;
        enemies.Add(newEnemy);
    }

    private void SpawnDragonEnemy()
    {

        Vector2 behindPlayer = new Vector2(playerCamera.transform.forward.x, playerCamera.transform.forward.z) * -1;
        behindPlayer = behindPlayer.normalized;

        float distRange = Random.Range(minSpawnRange, maxSpawnRange);
        float diffRange = Random.Range(-30.0f, 30.0f);

        behindPlayer *= distRange;

        Vector2 perp = Vector2.Perpendicular(behindPlayer).normalized;
        perp *= diffRange;

        behindPlayer += perp;

        Vector3 newPos = new Vector3(playerCamera.transform.position.x + behindPlayer.x, 10, playerCamera.transform.position.z + behindPlayer.y);

        GameObject newEnemy = Instantiate(dragonEnemy, newPos, Quaternion.identity);
        newEnemy.GetComponent<DragonEnemy>().targetTransform = playerCamera.transform;
        enemies.Add(newEnemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemyKills++;
        if (enemyKills >= waveIncreaseThreshold)
        {
            SpawnDragonEnemy();
            currentSpawnNum++;
            enemyKills = 0;
        }

        enemies.Remove(enemy);
    }
}
