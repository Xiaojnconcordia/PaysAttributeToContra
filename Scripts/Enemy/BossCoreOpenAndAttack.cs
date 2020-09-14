using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoreOpenAndAttack : MonoBehaviour
{
    private float currentTime;
    private float OpenTime = 9.5f;
    private EnemyAnimation enemyAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = OpenTime / 2;
        enemyAnim = GetComponentInChildren<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        BossOpen();
    }

    private void BossOpen()
    {
        currentTime += Time.deltaTime;
        if (currentTime > OpenTime)
        {
            enemyAnim.BossOpen();
            currentTime = 0;
        }
    }
}
