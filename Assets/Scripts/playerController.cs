using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float MAX_Y = 4.3f;
    public float rotationSpeed = 180.0f;
    public float ySpeed = 5.0f;
    public int ammo = 10;
    public ObjectPool blasterPool;
    public GameObject shotPrefab;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        blasterPool = new ObjectPool(shotPrefab, ammo);
    }

    // Update is called once per frame
    void Update()
    {

        float rotationInput = Input.GetAxis("Horizontal");
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        playerTransform.Rotate(Vector3.forward, rotationAmount);


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
            transform.position = pos;
    }

    void Shoot()
    {
        GameObject blaster = blasterPool.GetFromPool();

        if (blaster != null)
        {
            Vector2 pos = transform.position;

            Vector2 direction = playerTransform.up;

            blaster.GetComponent<shotController>().SetDirection(direction);

            blaster.transform.position = pos;
            blaster.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Friendly"))
            UnityEditor.EditorApplication.isPlaying = false;
    }
}
