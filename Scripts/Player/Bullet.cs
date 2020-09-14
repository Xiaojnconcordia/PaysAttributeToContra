using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 300;
    public float playerDamage = 20;
    private float enemyDamage = 1;
    public GameObject hitEffect;    
    private Rigidbody rb;

    public bool isPlayer;
    public bool isEnemy;
    public bool isBossCore;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBossCore)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.forward * speed;
        }        
        //transform.Translate(transform.forward * speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            if (other.CompareTag("Enemy"))
            {
                //make damage
                //Debug.Log("Enemy Damaged!");

                // make damage on other object, which is enemy in this case
                other.GetComponent<HealthManagement>().takeDamage(playerDamage);

                //display hit effect at the collision point
                if (hitEffect != null)
                {
                    Instantiate(hitEffect, transform.position, Quaternion.identity);
                }

                // play hit sound
                GameObject.FindWithTag("Player").GetComponentInChildren<AnimationEvent>().PlayerHitEnemySound();

                // destroy the bullet
                Destroy(gameObject);
            }
        }
       
        else //else if (isEnemy || isBossCore)
        {
            if (other.CompareTag("Player"))
            {
                //Debug.Log("Player Damaged!");

                // make damage on other object, which is the player in this case
                other.GetComponent<HealthManagement>().takeDamage(enemyDamage);
            }
        }
    }
}
