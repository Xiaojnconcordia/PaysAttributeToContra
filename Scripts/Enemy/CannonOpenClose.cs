using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonOpenClose : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;
    public Transform cannonBase;
    public GameObject cannonBullet;
    public float range;
    private float currentTime;
    private float defaultFireTime = 3;
    private EnemyAnimation animScript;    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = defaultFireTime / 2 ; 
        animScript = GetComponentInChildren<EnemyAnimation>();
        
        GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < range)
        {
            animScript.CannonShouldOpen(true);
            GetComponent<BoxCollider>().enabled = true; // can only be attacked when it is open
            cannonBase.LookAt(target);
            currentTime += Time.deltaTime;
            if (currentTime > defaultFireTime)
            {
                Instantiate(cannonBullet, firePoint.position, firePoint.rotation);                
                GetComponentInChildren<AnimationEvent>().CannonShootSound();
                currentTime = 0f;
            }
            
        }
        else
        {
            animScript.CannonShouldOpen(false);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
