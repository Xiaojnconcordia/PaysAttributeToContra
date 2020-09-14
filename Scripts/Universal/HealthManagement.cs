using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    public Text livesText;
    public bool isPlayer;
    public bool isTank;
    public bool isCannon;
    public bool isBossCannon;
    public bool isBossCore;
    public GameObject gameOverMenu;
    public GameObject completeMenu;
    public float health = 100;
    private bool isInvincible;
    private float invincibleDuration = 4f;
    private Vector3 playerSpwanPos;
    private Vector3 fallRespawnOffset = new Vector3(-50, 0, 0);
    private float spwanYPos = 20;
    private float respawnTime = 1.0f;
    private float timer;        
    private float fallDamage = 1f;
    private bool CharacterDied;
    private bool fallToDeath;
    private EnemyAnimation enemyAnimScript;
    private PlayerAnimation playerAnimScript;
    private Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (isPlayer)
        {
            playerAnimScript = GetComponentInChildren<PlayerAnimation>();
            rb = GetComponent<Rigidbody>();            
        }

        else if (isBossCore)
        {
            enemyAnimScript = GetComponentInParent<EnemyAnimation>();
        }

        else
        {
            enemyAnimScript = GetComponentInChildren<EnemyAnimation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            playerSpwanPos = new Vector3(transform.position.x, spwanYPos, transform.position.z);
            CheckInvincible();
            livesText.text = health.ToString();


            // cheats
            if (Input.GetKeyDown(KeyCode.P))
            {
                health++;
            }
        }
        

    }

    public void takeDamage(float damage)
    {
        if (CharacterDied)
        {
            return;
        }

        // take damage before died or destroyed
        else
        {
            if (!isPlayer)
            {
                health -= damage;
            }
            
            if (isPlayer)
            {
                if (!isInvincible)
                {
                    health -= damage;
                    GetComponent<PlayerMovement>().isGrounded = true;
                    //playerAnimScript.PlayerGetHurt();
                    playerAnimScript.PlayerGetHurt();

                    // relocate at the top left
                    RelocatePlayer();
                }
            }
        }



        // if died or destroyed
        if (health <= 0f)
        {
            if (isTank)
            {
                //Debug.Log("Tanks is destroyed");

                //display tank destroyed animation
                enemyAnimScript.TankDestroyed();
                
                //disable tank collider
                GetComponent<BoxCollider>().enabled = false;

                //disable tank move and attack scripts
                GetComponent<TankMoveAndAttack>().tankRb.velocity = Vector3.zero;
                GetComponent<TankMoveAndAttack>().enabled = false;

            }
            if (isCannon)
            {   
                //display tank destroyed animation
                enemyAnimScript.CannonDestroyed();

                //disable cannon collider
                GetComponent<BoxCollider>().enabled = false;

                //disable cannon open and close               
                GetComponent<CannonOpenClose>().enabled = false;

            }

            if (isBossCannon)
            {                
                gameObject.SetActive(false);
            }

            if (isBossCore)
            {
                
                enemyAnimScript.BossExplosion();
                gameObject.SetActive(false);
                if (GameObject.Find("Cylinder") != null)
                {
                    GameObject.Find("Cylinder").SetActive(false);
                }

                if (GameObject.Find("Cylinder1") != null)
                {
                    GameObject.Find("Cylinder1").SetActive(false);
                }

                if (GameObject.Find("Cylinder2") != null)
                {
                    GameObject.Find("Cylinder2").SetActive(false);
                }


                GameObject.Find("Boss").GetComponent<BossCoreOpenAndAttack>().enabled = false;
                GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
                Invoke("CompleteLevel", 5.0f);
            }

            if (isPlayer)
            {
                Debug.Log("Player is destroyed");

                //display player death animation
                playerAnimScript.PlayerDied();

                //disable player collider
                GetComponent<BoxCollider>().enabled = false;

                //disable player move and attack scripts
                GetComponent<PlayerAttack>().enabled = false;
                GetComponent<PlayerMovement>().enabled = false;

                // game over menu
                GameOver();
            }
        }
    } // takeDamage

    private void RelocatePlayer()
    {
        StartCoroutine(RelocateAfterTime());
    }

    IEnumerator RelocateAfterTime()
    {
        isInvincible = true;
        yield return new WaitForSeconds(respawnTime);

        // if fall to death, respawn at a postion backward, so it will not fall at the same position
        if (fallToDeath == true)
        {
            rb.velocity = Vector3.zero; // otherwise player will respawn and drop down with a super fast speed because before the character was falling
            transform.position = playerSpwanPos + fallRespawnOffset;
            fallToDeath = false;
        }
        
        else
        {
            transform.position = playerSpwanPos;
        }

        // after relocating, player becomes invincible for a fixed time


        // enable invincible effect
        //GameObject.FindGameObjectWithTag("Halo").SetActive(true);  // cannot find with tag because this gameobject is inactive 
        transform.Find("BlueLight").gameObject.SetActive(true);
        GetComponent<PlayerAttack>().isPoweredUp = false;
    }

    private void CheckInvincible()
    {
        if (isInvincible)
        {            
            timer += Time.deltaTime;
            if (timer > invincibleDuration)
            {
                isInvincible = false;
                timer = 0;

                //turn off invincible effect                
                GameObject.FindGameObjectWithTag("Halo").SetActive(false);

            }
        }
    }
    void GameOver()
    {
        gameOverMenu.SetActive(true);
        Invoke("PauseGame", 1.0f);
    }
    void CompleteLevel()
    {  
        
        completeMenu.SetActive(true);
        Invoke("PauseGame", 2.0f);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            
            if (other.CompareTag("Bottom"))
            {
                fallToDeath = true;
                takeDamage(fallDamage);
            }
        }
    }
}
