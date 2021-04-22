using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
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
    Vector3 currPos;
    public GameObject player;
  

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        currPos = startPos;
    }

    private void Update()
    {
        float newX = currPos.x + Time.deltaTime * moveXSpeed;
        float newY = currPos.y + Time.deltaTime * moveYSpeed;
        float newZ = currPos.z + Time.deltaTime * moveZSpeed;

        if (Mathf.Abs(newX - startPos.x) >= moveXDistance)
        {
            moveXSpeed *= -1;
        }

        if (Mathf.Abs(newY - startPos.y) >= moveYDistance)
        {
            moveYSpeed *= -1;
        }

        if (Mathf.Abs(newZ - startPos.z) >= moveZDistance)
        {
            moveZSpeed *= -1;
        }

        Vector3 newPos = new Vector3(newX, newY, newZ);

        transform.position = newPos;
        currPos = newPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*float newX = startPos.x + (Mathf.Sin(Time.time * moveXSpeed) * moveXDistance);
        float newY = startPos.y + (Mathf.Sin(Time.time * moveYSpeed) * moveYDistance);
        float newZ = startPos.z + (Mathf.Sin(Time.time * moveZSpeed) * moveZDistance);*/

    }


}
