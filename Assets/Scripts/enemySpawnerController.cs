using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerController : MonoBehaviour
{
    public float speed = 2;
    private float direction;
    public ObjectPool straightEnemyPool;
    public int straightEnemyAmount = 5;
    public GameObject straightEnemyPrefab;
    public ObjectPool sinusoidalEnemyPool;
    public ObjectPool sinusoidalEnemyPrefab;
    public ObjectPool aproachingEnemyPool;
    public ObjectPool aproachingEnemyPrefab;

    public float minInterval = 0.2f;
    public float maxInterval = 10000f;

    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        straightEnemyPool = new ObjectPool(straightEnemyPrefab, straightEnemyAmount);
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
        straightEnemySpawn();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.y += speed * Time.deltaTime * direction;

        if (pos.y > 4.3f)
        {

            direction = -1;
        }
        else if (pos.y < -4.3f)
        {
            direction = 1;
        }

        transform.position = pos;



        // if (Time.time >= nextSpawnTime)
        // straightEnemySpawn();
    }

    void straightEnemySpawn()
    {
        GameObject straightEnemy = straightEnemyPool.GetFromPool();

        if (straightEnemy != null)
        {
            Vector2 pos = transform.position;
            straightEnemy.transform.position = pos;
            straightEnemy.SetActive(true);

        }
    }

}
