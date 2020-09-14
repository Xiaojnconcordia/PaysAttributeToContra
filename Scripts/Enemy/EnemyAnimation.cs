using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TankDestroyed()
    {
        animator.SetTrigger("TankDestroyed");
    }

    public void CannonShouldOpen(bool b)
    {
        animator.SetBool("ShouldOpen", b);
    }

    public void CannonDestroyed()
    {
        animator.SetTrigger("CannonDestroyed");
    }

    public void BossOpen()
    {
        animator.SetTrigger("BossOpen");
    }

    public void BossExplosion()
    {
        animator.SetTrigger("BossExplosion");
    }
}
