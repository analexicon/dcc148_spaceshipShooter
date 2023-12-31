using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerController : MonoBehaviour
{
    public float speed = 3;
    private float direction;
    public ObjectPool straightEnemyPool;
    public int straightEnemyAmount = 20;
    public GameObject straightEnemyPrefab;
    public ObjectPool aproachingEnemyPool;
    public int aproachingEnemyAmount = 10;
    public GameObject aproachingEnemyPrefab;
    public ObjectPool sinusoidalEnemyPool;
    public int sinusoidalEnemyAmount = 10;
    public GameObject sinusoidalEnemyPrefab;

    public float minSpawnInterval = 0.8f;
    public float maxSpawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        straightEnemyPool = new ObjectPool(straightEnemyPrefab, straightEnemyAmount);
        aproachingEnemyPool = new ObjectPool(aproachingEnemyPrefab, aproachingEnemyAmount); // Crie uma piscina para aproachingEnemy
        sinusoidalEnemyPool = new ObjectPool(sinusoidalEnemyPrefab, sinusoidalEnemyAmount);

        Invoke("SpawnStraightEnemy", Random.Range(minSpawnInterval, maxSpawnInterval));
        Invoke("SpawnAproachingEnemy", Random.Range(2 * minSpawnInterval, 2 * maxSpawnInterval));
        Invoke("SpawnSinusoidalEnemy", Random.Range(4 * minSpawnInterval, 4 * maxSpawnInterval));
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
    }

    void SpawnStraightEnemy()
    {
        GameObject straightEnemy = straightEnemyPool.GetFromPool();

        if (straightEnemy != null)
        {
            Vector2 pos = transform.position;
            straightEnemy.transform.position = pos;
            straightEnemy.SetActive(true);
        }

        Invoke("SpawnStraightEnemy", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnAproachingEnemy()
    {
        GameObject aproachingEnemy = aproachingEnemyPool.GetFromPool();

        if (aproachingEnemy != null)
        {
            Vector2 pos = transform.position;
            aproachingEnemy.transform.position = pos;
            aproachingEnemy.SetActive(true);
        }

        Invoke("SpawnAproachingEnemy", Random.Range(2 * minSpawnInterval, 2 * maxSpawnInterval));
        if (maxSpawnInterval > 0.9f)
            maxSpawnInterval -= 0.1f;
    }

    void SpawnSinusoidalEnemy()
    {
        GameObject sinusoidalEnemy = sinusoidalEnemyPool.GetFromPool();

        if (sinusoidalEnemy != null)
        {
            Vector2 pos = transform.position;
            sinusoidalEnemy.transform.position = pos;
            sinusoidalEnemy.SetActive(true);
        }

        Invoke("SpawnSinusoidalEnemy", Random.Range(3 * minSpawnInterval, 3 * maxSpawnInterval));
    }
}
