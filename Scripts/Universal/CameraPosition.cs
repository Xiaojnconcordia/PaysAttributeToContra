using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollowTarget();
    }


    void CameraFollowTarget()
    {
        transform.localPosition = new Vector3(target.position.x + offset.x, offset.y, offset.z);
    }
}
