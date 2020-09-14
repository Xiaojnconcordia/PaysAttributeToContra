using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
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


    public void PlayerWalk(bool b)
    {
        animator.SetBool("PlayerWalk", b);
    }

    public void PlayerJump()
    {
        animator.SetTrigger("Jump");
    }

    public void PlayerShoot()
    {
        animator.SetTrigger("Shoot");
    }

    public void PlayerShootUp()
    {
        animator.SetTrigger("ShootUp");
    }

    public void PlayerShootUpLR()
    {
        animator.SetTrigger("ShootUpLR");
    }

    public void PlayerShootDownLR()
    {
        animator.SetTrigger("ShootDownLR");
    }

    public void PlayerLieDown(bool b)
    {
        animator.SetBool("LaidDown", b);
    }

    public void PlayerGetHurt()
    {
        animator.SetTrigger("PlayerHurt");
    }

    public void PlayerDied()
    {
        animator.SetTrigger("PlayerDied");
    }
}
