using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float xSpeed;

    private float maxX = 8;
    private float maxY = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inputDeltaX = Input.GetAxis("Horizontal");
        float playerDeltaX = inputDeltaX * xSpeed * Time.deltaTime;
        float newPositionX = this.transform.position.x + playerDeltaX;
        this.transform.Translate(newPositionX, 0, );
    }
}
