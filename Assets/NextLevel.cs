using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private LevelManager levelM;

        void Start()
    {
        
        this.levelM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
    }

    private void OnTriggerEnter(Collider other){

             if(other.CompareTag("Player")){

                levelM.LevelBeat();
        }
    }
}
