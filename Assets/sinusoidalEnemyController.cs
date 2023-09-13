using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyEnemyController : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90.0f;
    public float amplitude = 3.0f;
    public float frequency = 5.0f;

    private Vector2 posUpdater;
    private float initialX;
    private float initialY;

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
        posUpdater.y = initialY + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = posUpdater;

        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);

        float minPos = -8;
        if (transform.position.x < minPos)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);
    }
}
