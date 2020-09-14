using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject explosionFX;
    public GameObject powerUpRb;  // after destroy the powerUp, this should be instantiate

    public float speed;
    public float ySpeed;
    private float multiplyer = 4f;

    private Vector3 nextPos;
    private Vector3 startPos;
    private Vector3 endPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpMove();
    }

    private void PowerUpMove()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.Translate(Vector3.up * ySpeed * Mathf.Sin(Time.time * multiplyer) *Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // instantiate explosion FX
            Instantiate(explosionFX, transform.position, Quaternion.identity);



            Destroy(other);
            Destroy(gameObject);


            // instantiate power up that player can get
            Instantiate(powerUpRb, transform.position, Quaternion.identity);


       
        }
    }
}
