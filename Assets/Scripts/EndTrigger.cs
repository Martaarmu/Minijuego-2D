using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameController gameController;
    
   public void OnTriggerEnter2D(Collider2D collision){
       
       gameController.CompleteLevel();
   }
}
