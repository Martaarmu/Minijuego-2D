using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
   
    public GameObject John;

    public void OnTriggerEnter2D(Collider2D collision){
       
       if(collision.CompareTag("Player")){

           JohnMovement john = collision.GetComponent<JohnMovement>();
           GetComponent<SpriteRenderer>().enabled = false;

        
        
           
           john.ganar();
           

       }
   }


    
}
