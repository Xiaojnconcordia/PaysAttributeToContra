using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannonBall : MonoBehaviour
{
    private Rigidbody rb;
    private float force;
    private float bossCannonDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        force = Random.Range(8, 16);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthManagement>().takeDamage(bossCannonDamage);
        }
    }

}
