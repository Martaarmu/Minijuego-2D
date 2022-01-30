using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : GameManager
{
  

    public void CompleteLevel(){
    
            Debug.Log("LEVEL WON!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CompleteGame(){
    
            Debug.Log("HAS GANADO EL JUEGO");
            
    }
    public void EndGame(){
            Debug.Log("GAME OVER");
            Restart();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     

    
    
}
