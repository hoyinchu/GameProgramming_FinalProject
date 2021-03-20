using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public float throwForce = 10f;
    public Camera cm;

    public AudioClip boxPickupSFX;
    public AudioClip boxThrowSFX;
    public AudioClip teleportSFX;

    bool isPickedUp;
    GameObject throwObject;
    CharacterController cc;
    Rigidbody rb;

    
    
    
    void Start()
    {
        isPickedUp = false;
        cc = gameObject.GetComponent<CharacterController>();

        //child = GameObject.FindGameObjectWithTag("ThrowObject");
    } 

    // Update is called once per frame
    void Update()
    {
        if(isPickedUp){
            if(Input.GetButtonDown("Fire2")){

                DropObject();


            }

            if(Input.GetButtonDown("Fire1")){

                ThrowObject();


            }
        }
        else{

            if(Input.GetKeyDown(KeyCode.T) && throwObject != null){

                Teleport();
            }


        }
    }

    private void OnTriggerStay(Collider other){

        
        if(other.CompareTag("ThrowObject")){

            if(Input.GetKeyDown(KeyCode.E) && !isPickedUp){
                PickupBox(other);

            }

        }

    }

    private void PickupBox(Collider other)
    {
        AudioSource.PlayClipAtPoint(boxPickupSFX, transform.position);

        other.gameObject.transform.parent = cm.transform;

        throwObject = other.gameObject;
        rb = throwObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //rb.useGravity = false;

        throwObject.transform.localPosition = new Vector3(0, 0, 1);
        throwObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        //throwObject.transform.localScale = new Vector3(0, 0, 0);

        isPickedUp = true;
        Debug.Log("Item Was Picked Up");
    }


    private void DropObject(){

        Debug.Log("Item Was Dropped");
        
        throwObject.transform.parent = null;
        rb.isKinematic = false;
        //rb.useGravity = true;
      

        isPickedUp = false;



    }

    private void ThrowObject(){

        Debug.Log("Item Was Thrown");
        AudioSource.PlayClipAtPoint(boxThrowSFX, transform.position);

        //rb.useGravity = true;
        rb.isKinematic = false;

        rb.AddForce(cm.transform.forward * throwForce, ForceMode.Impulse);
        throwObject.transform.parent = null;
        
        //child = null;
        isPickedUp = false;

    }

    private void Teleport(){

        Debug.Log("Teleported!");
        AudioSource.PlayClipAtPoint(teleportSFX, transform.position);

        cc.enabled = false;
        transform.position = throwObject.transform.position + Vector3.up;

        cc.enabled = true;
        Debug.Log("Player Position: " + transform.position);
        Debug.Log("Child Position: " + throwObject.transform.position);
    }
}
