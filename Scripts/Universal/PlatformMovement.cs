using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float xRange1;
    public float xRange2;
    public float yRange;
    public float speed = 1;    
    public bool horizontal;
    public bool vertical;
    private Vector3 nextPos;
    private Vector3 startPos;
    private Vector3 endPos;
    

    
    // Start is called before the first frame update
    void Start()
    {
        if (horizontal)
        {
            startPos = new Vector3(xRange1, transform.position.y, transform.position.z);
            endPos = new Vector3(xRange2, transform.position.y, transform.position.z);
        }

        if (vertical)
        {
            startPos = new Vector3(transform.position.x, yRange, transform.position.z);
            endPos = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        nextPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatForm();
    }

    public void MovePlatForm()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, speed);
        ChangeDestination();
    }

    public void ChangeDestination()
    {
        if(Vector3.Distance(transform.localPosition, nextPos) < 0.1f)
        {
            // if nextPos is startPos, let nextPos be endPos. Otherwise let nextPse be startPos
            nextPos = nextPos == startPos ? endPos : startPos;
        }
    }
}
