using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpMoveTrigger : MonoBehaviour
{
    Transform playerTarget;
    private float range = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTarget.position, transform.position) < range)
        {
            GetComponent<PowerUp>().enabled = true;
        }
    }
}
