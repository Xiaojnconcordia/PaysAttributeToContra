using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Boss").GetComponent<BossCoreOpenAndAttack>().enabled = true;            
            GameObject.Find("Cylinder").GetComponent<BossAttack>().enabled = true;            
            GameObject.Find("Cylinder1").GetComponent<BossAttack>().enabled = true;            
            GameObject.Find("Cylinder2").GetComponent<BossAttack>().enabled = true;   
        }
    }

}
