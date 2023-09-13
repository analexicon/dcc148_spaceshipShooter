using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightEnemyController : MonoBehaviour
{
    public float speed = 3;
    public float initialX;
    public float initialY;

    private Vector2 posUpdater;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        Debug.Log(enemySpawner.transform.position.x);
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
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}
