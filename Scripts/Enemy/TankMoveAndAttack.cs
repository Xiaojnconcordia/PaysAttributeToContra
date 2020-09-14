using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveAndAttack : MonoBehaviour
{
    public float speed;    
    public float detectTargetInDistance = 20;
    public Transform playerTarget;

    public GameObject tankBullet;
    public Transform tankFirePoint;

    public Rigidbody tankRb;
    private float defaultAttackTime = 4;
    private float currrentAttackTime;
    private float tankTouchDamage = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        tankRb = GetComponent<Rigidbody>();
        currrentAttackTime = defaultAttackTime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndAttackPlayer();
    }

    private void MoveAndAttackPlayer()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) < detectTargetInDistance)
        {
            tankRb.velocity = transform.forward * speed;

            currrentAttackTime += Time.deltaTime;
            if (currrentAttackTime > defaultAttackTime)
            {
                Instantiate(tankBullet, tankFirePoint.position, tankFirePoint.rotation);
                GetComponentInChildren<AnimationEvent>().TankShootSound();
                currrentAttackTime = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if tank collides with player, the player should be damaged
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthManagement>().takeDamage(tankTouchDamage);
        }
    }
}
