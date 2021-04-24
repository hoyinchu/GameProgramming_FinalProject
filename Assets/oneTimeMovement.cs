using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeMovement : MonoBehaviour
{

    // The distance in which the platform will move to
    public float moveXDistance = 0;
    public float moveYDistance = 0;
    public float moveZDistance = 0;

    // The speed in which the platform will move with in that direction
    public float moveXSpeed = 1;
    public float moveYSpeed = 1;
    public float moveZSpeed = 1;

    Vector3 startPos;
    Vector3 destPos;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        destPos = new Vector3(startPos.x+moveXDistance, startPos.y+moveYDistance, startPos.z+moveZDistance);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Mathf.Abs(startPos.x - currPos.x) < moveXDistance)
        {
            currPos.x += moveXSpeed * Time.deltaTime;
        }

        if (Mathf.Abs(startPos.y - currPos.y) < moveYDistance)
        {
            currPos.y += moveYSpeed * Time.deltaTime;
        }

        if (Mathf.Abs(startPos.z - currPos.z) < moveZDistance)
        {
            currPos.z += moveZSpeed * Time.deltaTime;
        }
        */
        transform.position = Vector3.Lerp(transform.position, destPos, Time.deltaTime);

    }
}
