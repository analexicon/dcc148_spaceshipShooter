using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class playerController : MonoBehaviour
{
    private float vx;
    private float MAX_Y = 4.3f;
    private bool nextBlaster;
    public float ySpeed = 3.5f;
    public int ammo = 10;
    public ObjectPool blasterPool;
    public GameObject shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        nextBlaster = true;
        blasterPool = new ObjectPool(shotPrefab, ammo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float vy = Input.GetAxis("Vertical") * ySpeed;

        Vector2 v = new Vector2(0, vy);

        pos += v * Time.fixedDeltaTime;

        if (pos.y < MAX_Y && pos.y > -MAX_Y)
        {
            transform.position = pos;
        }
    }


    void Shoot()
    {
        GameObject blaster = blasterPool.GetFromPool();

        if (blaster != null)
        {
            Vector2 pos = transform.position;
            Vector2 wingLenght = new Vector2(0, 0.45f);
            if (nextBlaster)

                pos += wingLenght;
            else
                pos -= wingLenght;

            nextBlaster = !nextBlaster;
            blaster.transform.position = pos;
            blaster.SetActive(true);
        }
    }
}
