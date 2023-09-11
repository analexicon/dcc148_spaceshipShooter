using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private float vx;
    private float MAX_Y = 4;
    public float ySpeed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // capturando o inicial
        Vector2 pos = transform.position;
        float vy = Input.GetAxis("Vertical") * ySpeed;

        Vector2 v = new Vector2(0, vy);
        // somando ao inicial
        pos += v * Time.fixedDeltaTime;

        //implicitamente a nave
        if (pos.y < MAX_Y && pos.y > -MAX_Y)
        {
            transform.position = pos;
        }
    }
}