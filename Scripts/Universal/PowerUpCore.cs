using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCore : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 3;
    public AudioClip explosionSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // play shell explosion sound
        audioSource.volume = 0.5f;
        audioSource.clip = explosionSound;
        audioSource.Play();

        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        int r = Random.Range(0,2);
        if (r == 0)
        {
            rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        }

        else
        {
            rb.AddForce(Vector3.right * -force, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (rb.velocity.y < 0)
            {
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
            }
          
        }
    }
}
