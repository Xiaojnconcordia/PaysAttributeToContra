using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRb;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float jumpUpGravityMultiplayer = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float checkRadius = 0.2f;
    private float walk_rotate = 90f;
    private PlayerAnimation animScript;

    public bool isGrounded;
    public bool isLaidDown;
    public bool isOnPlatform;    
    private Vector3 originalColliderSize;
    private Vector3 newColliderSize = new Vector3(0.3f, 0.2f, 1.5f);
    private float originalCenterY;
    private float newCenterY = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        animScript = GetComponentInChildren<PlayerAnimation>();
        playerRb = GetComponent<Rigidbody>();

        originalColliderSize = GetComponent<BoxCollider>().size;
        originalCenterY = GetComponent<BoxCollider>().center.y;       

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLaidDown)
        {
            MovePlayer();
            RotateWhenWalking();
            PlayerJump();
            WalkAnimation();
        }  
        if (isGrounded)
        {
            LieDownAnimation();
        }

        // when lie down, collider should be lowered too
        ChangeColliderSize();
        
        
        CheckGround();
        NoCollisionWhenJumpUp();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector3(horizontal * speed * Time.deltaTime, playerRb.velocity.y, playerRb.velocity.z);
    }

    private void RotateWhenWalking()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) // move right            
        {
            playerRb.rotation = Quaternion.Euler(0f, walk_rotate, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") < 0) // move left            
        {
            playerRb.rotation = Quaternion.Euler(0f, -walk_rotate, 0f);
        }
    }

    private void NoCollisionWhenJumpUp() // not collider with ground while jumping
    {
        if (!isGrounded)
        {    
            Physics.IgnoreLayerCollision(0, 8, true);
        }

        else
        { 
            Physics.IgnoreLayerCollision(0, 8, false);
        }
    }


    private void WalkAnimation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0
            && isGrounded)
        {
            animScript.PlayerWalk(true);
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animScript.PlayerWalk(false);
        }
    }

    private void LieDownAnimation()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            animScript.PlayerLieDown(true);
            isLaidDown = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animScript.PlayerLieDown(false);
            isLaidDown = false;
        }
    }

    public void PlayerJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isGrounded = false;
            animScript.PlayerJump();
        }
        // make the player fall faster, so it does't feel like the character is floating in the air
        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }

        // when jumping up, if not holding the I key, the jump will have more gravity. Thus, if holding the jump key, the jump will be higher. 
        else if (playerRb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * jumpUpGravityMultiplayer * Time.deltaTime;
        }


    }

    // make the ground be a parent of the player when standing on it, 
    // so when the platform is going downword, player will not keep falling when platform is moving faster than the gravity pulling down the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
            isOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        transform.parent = null;
        isOnPlatform = false ;

    }


    private void CheckGround()
    {
        
        if (playerRb.velocity.y > 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        }
        
        if (isOnPlatform)
        {
            isGrounded = true;
        }

    }

    private void ChangeColliderSize()
    {
        if (isLaidDown)
        {
            GetComponent<BoxCollider>().size = newColliderSize;
            GetComponent<BoxCollider>().center = new Vector3(GetComponent<BoxCollider>().center.x, newCenterY, GetComponent<BoxCollider>().center.z);
        }
        else
        {
            GetComponent<BoxCollider>().size = originalColliderSize;
            GetComponent<BoxCollider>().center = new Vector3(GetComponent<BoxCollider>().center.x, originalCenterY, GetComponent<BoxCollider>().center.z);
        }
            
    }
}
