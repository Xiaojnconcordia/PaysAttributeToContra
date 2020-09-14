using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bossCannonPrefab;
    private float currentTime;
    private float fireTime;    
    private AnimationEvent eventScript;
    // Start is called before the first frame update
    void Start()
    {
        eventScript = GetComponentInParent<AnimationEvent>();
        fireTime = 4;
        currentTime = fireTime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        BossCannonAttack();
    }

    void BossCannonAttack()
    {
        
        currentTime += Time.deltaTime;
        if (currentTime > fireTime)
        {
            Instantiate(bossCannonPrefab, firePoint.position, firePoint.rotation);
            eventScript.BossCannonSoundFX();
            currentTime = 0;
            fireTime = Random.Range(2, 6);  // 2, 3, 4, 5
        }
    }


}
