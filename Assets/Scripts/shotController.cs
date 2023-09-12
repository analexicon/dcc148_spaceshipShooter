using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotController : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        Vector2 maxPos = new Vector2(8, 0);
        if (transform.position.x > maxPos.x)
            gameObject.SetActive(false);
    }
}
