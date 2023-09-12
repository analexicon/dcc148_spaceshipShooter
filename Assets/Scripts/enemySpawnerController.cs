using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerController : MonoBehaviour
{
    public float speed = 2;
    private float direction;
    public ObjectPool straightEnemyPool;
    public GameObject straightEnemyPrefab;
    public ObjectPool sinusoidalEnemyPool;
    public ObjectPool sinusoidalEnemyPrefab;
    public ObjectPool aproachingEnemyPool;
    public ObjectPool aproachingEnemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
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
}
