using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightEnemyController : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x -= speed * Time.deltaTime;

        transform.position = pos;

        Vector2 minPos = new Vector2(-8, 0);
        if (transform.position.x < minPos.x)
            gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);
    }
}
