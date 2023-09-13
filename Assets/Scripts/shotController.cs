using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotController : MonoBehaviour
{
    private float speed = 10;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
    }


    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        transform.position = pos;

        Vector2 maxPos = new Vector2(8, 5);
        if (transform.position.x > maxPos.x || transform.position.y > maxPos.y || transform.position.y < -maxPos.y)
            gameObject.SetActive(false);
    }
}
