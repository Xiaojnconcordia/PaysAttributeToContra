using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject poweredUpBullet;
    private GameObject currentBullet;
    private PlayerAnimation animScript;
    private PlayerMovement moveScript;
    public bool isPoweredUp;


    private float fireRate = 2;
    private float fireNextTime = 0;

    private void Start()
    {
        animScript = GetComponentInChildren<PlayerAnimation>();
        moveScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        CheckBulletType();
    }

    void Shoot()
    {
        if (Time.time > fireNextTime)
        {
            

            if (Input.GetKey(KeyCode.W))
            {
                
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))  // shoot upright or upleft
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        // shoot upleftOrRight animation
                        animScript.PlayerShootUpLR();
                        
                        // play shoot sourd
                        GetComponentInChildren<AnimationEvent>().PlayerShootSound();

                        // spawn a bullet
                        Instantiate(currentBullet, firePoint.position, firePoint.rotation * Quaternion.Euler(-45, 0, 0));
                        fireNextTime = Time.time + 1 / fireRate;
                    }
                }
                else  // shoot upward
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        // shoot up animation
                        animScript.PlayerShootUp();

                        // play shoot sourd
                        GetComponentInChildren<AnimationEvent>().PlayerShootSound();

                        // spawn a bullet
                        Instantiate(currentBullet, firePoint.position, firePoint.rotation * Quaternion.Euler(-90, 0, 0));
                        fireNextTime = Time.time + 1 / fireRate;
                    }
                } 
            }

            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) // shoot downright or downleft
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        // shoot downleftOrRight animation
                        animScript.PlayerShootDownLR();

                        // play shoot sourd
                        GetComponentInChildren<AnimationEvent>().PlayerShootSound();

                        // spawn a bullet
                        Instantiate(currentBullet, firePoint.position, firePoint.rotation * Quaternion.Euler(45, 0, 0));
                        fireNextTime = Time.time + 1 / fireRate;
                    }
                }
                else if (!moveScript.isGrounded) // can shoot downward when jumping
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {

                        // keep jump animation, no shoot animation here. 

                        // play shoot sourd
                        GetComponentInChildren<AnimationEvent>().PlayerShootSound();

                        // spawn a bullet
                        Instantiate(currentBullet, firePoint.position, firePoint.rotation * Quaternion.Euler(90, 0, 0));


                        fireNextTime = Time.time + 1 / fireRate;
                    }
                }

                else // if grounded, lie down and shoot forward
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        // play shoot sourd
                        GetComponentInChildren<AnimationEvent>().PlayerShootSound();

                        // spawn a bullet
                        Instantiate(currentBullet, firePoint.position, firePoint.rotation);
                        fireNextTime = Time.time + 1 / fireRate;
                    }
                }
            }


            else // shoot forward
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    
                    // shoot animation
                    animScript.PlayerShoot();

                    // play shoot sourd
                    GetComponentInChildren<AnimationEvent>().PlayerShootSound();

                    // spawn a bullet
                    Instantiate(currentBullet, firePoint.position, firePoint.rotation);
                    fireNextTime = Time.time + 1 / fireRate;
                }
            }
        }
    } //shoot

    private void CheckBulletType()
    {
        if (isPoweredUp)
        {
            currentBullet = poweredUpBullet;
        }

        else
        {
            currentBullet = bullet;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPoweredUp = true;
            GetComponentInChildren<AnimationEvent>().PowerUpSound();
            other.gameObject.SetActive(false);            
        }
    }
}
