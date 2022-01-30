using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    public AudioClip Sound;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity=Direction * Speed;
    }

    public void SetDirection(Vector2 direction){
        Direction=direction;
    }

    /**Método para cuando se acabe la animación de la bala
    se destruya.
    */
    public void DestroyBullet(){
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision){

        JohnMovement john = collision.collider.GetComponent<JohnMovement>();
        GruntScript grunt = collision.collider.GetComponent<GruntScript>();
        
        if(john !=null){
           john.Hit();
          
        }
        if(grunt !=null){
            grunt.Hit();
        }
  
        DestroyBullet();
    }
}
