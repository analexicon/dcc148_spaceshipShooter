using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aproachingEnemyController : MonoBehaviour
{
    public float speed = 3;
    public float initialX;
    public float initialY;
    public float increaseSpeed = 0.1f;
    public float maxSize = 0.2f;

    private Vector2 posUpdater;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemySpawner = GameObject.Find("EnemySpawner");

        if (enemySpawner != null)
        {
            initialY = enemySpawner.transform.position.y;
            initialX = enemySpawner.transform.position.x;

            posUpdater = new Vector2(initialX, initialY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        posUpdater.x -= speed * Time.deltaTime;
        posUpdater.y = initialY;
        transform.position = posUpdater;

        float minPos = -8;
        if (transform.position.x < minPos)
            gameObject.SetActive(false);


        float newSize = Mathf.Min(transform.localScale.x + increaseSpeed * Time.deltaTime, maxSize);
        transform.localScale = new Vector3(newSize, newSize, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}
