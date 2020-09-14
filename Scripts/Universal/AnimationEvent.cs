using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    
    public AudioClip hitSound, tankDestroySound, cannonDestroyedSound, playerShootSound, playerJumpSound, playerHurtSound, playerDieSound, tankShootSound,
        cannonShootSound, powerUpSound, bossCannonSound, bossCoreFireSound, bossExplosionSound, completeLevelSound;
    public AudioSource audioSource;
    public GameObject bossCoreBulletPrefab;
    public Transform bossCore;
    private Quaternion bossFireRotation = Quaternion.Euler(0, 0, 90f);    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisablePlayerMoveAndAttack()
    {
        GetComponentInParent<PlayerAttack>().enabled = false;
        GetComponentInParent<PlayerMovement>().enabled = false;
    }

    public void EnablePlayerMoveAndAttack()
    {
        GetComponentInParent<PlayerAttack>().enabled = true;
        GetComponentInParent<PlayerMovement>().enabled = true;
    }


    public void PlayerHitEnemySound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = hitSound;
        audioSource.Play();
    }
    public void PlayerJumpSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = playerJumpSound;
        audioSource.Play();
    }

    public void PlayerShootSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = playerShootSound;
        audioSource.Play();
    }

    public void PlayerHurtSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = playerHurtSound;
        audioSource.Play();
    }

    public void PlayerDieSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = playerDieSound;
        audioSource.Play();
    }

    public void TankDestroyedSound()
    {
        audioSource.volume = 0.4f;
        audioSource.clip = tankDestroySound;
        audioSource.Play();
    }

    public void TankShootSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = tankShootSound;
        audioSource.Play();
    }

    public void CannonDestroyedSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = cannonDestroyedSound;
        audioSource.Play();
    }

    public void CannonShootSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = cannonShootSound;
        audioSource.Play();
    }

    public void PowerUpSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = powerUpSound;
        audioSource.Play();
    }

    public void BossCannonSoundFX()
    {
        audioSource.volume = 0.1f;
        audioSource.clip = bossCannonSound;
        audioSource.Play();
    }

    public void BossCoreFire()
    {
        audioSource.volume = 0.1f;
        audioSource.clip = bossCoreFireSound;
        audioSource.Play();
        Instantiate(bossCoreBulletPrefab, bossCore.position, bossCore.rotation * bossFireRotation);
    }

    public void BossExplosionSoundFX()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = bossExplosionSound;
        audioSource.Play();        
    }

    public void CompleteLevelSoundFX()
    {
        audioSource.volume = 1.0f;
        audioSource.clip = completeLevelSound;
        audioSource.Play();
    }

    public void BossCoreColliderOn()
    {
        bossCore.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void BossCoreColliderOff()
    {
        bossCore.gameObject.GetComponent<BoxCollider>().enabled = false;
    }





}
