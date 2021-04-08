using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpHeight = 2;
    public float gravity = 9.801f;
    public float airControl = 10;
    public AudioClip stepSFX;

    CharacterController controller; 
    Vector3 input;
    Vector3 moveDirection;
    Rigidbody playerRigidBody;
    bool isOnSlope = false;
    float maxSlopeAngle = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;
        input *= moveSpeed;

        if(controller.isGrounded & !isOnSlope) {

            

            //we can jump

            moveDirection = input;

            
            if(Input.GetButton("Jump")) {

                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
                AudioSource.PlayClipAtPoint(stepSFX, transform.position);


            }
            else { 

                moveDirection.y = 0.0f;

            }
        }
        else {

            //we are mid-air

            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        isOnSlope = hit.normal.y <= maxSlopeAngle;
        if (controller.isGrounded && hit.transform.tag == "MovingPlatform")
        {
            transform.SetParent(hit.transform);
        }
        else if (controller.isGrounded && hit.transform.tag != "MovingPlatform")
        {
            transform.parent = null;
        }
        
    }

}
