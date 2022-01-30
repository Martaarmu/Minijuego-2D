using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JohnMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    public GameObject BulletPrefab;
    private float LastShoot; //Para que cada vez que disparemos no salgan muchas balas
     public GameObject [] hearts;
    public GameObject vida;
    private int life;

    void Start()
    {
        life=hearts.Length;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal"); //valores de -1 a 1

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }else{
            Grounded = false;
        }


        //Horizontal= -1 -> mira hacia la izquierda x=-0.1f y al revés
        if(Horizontal<0.0f){
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }else if(Horizontal > 0.0f){
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        Animator.SetBool("running", Horizontal!=0.0f);

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

        if(Input.GetKey(KeyCode.Space) && Time.time> LastShoot +0.25f){
            Shoot();
            LastShoot = Time.time;
        }

        if(Rigidbody2D.position.y < -2){
            FindObjectOfType<GameController>().EndGame();
        }

        
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f){
            direction = Vector2.right;
        }else{
            direction= Vector2.left;
        }
      
        GameObject bullet =  Instantiate(BulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    /**
    * A -> Horizontal=-1 (izquierda)
    * D -> Horizontal=1 (derecha)
    */
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal,Rigidbody2D.velocity.y);
    }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Hit(){

      life--;
      checkLifeLose();
        
    }

    public void ganar()  {
        life++;
        checkLifeWin();
    }
   public void checkLifeLose(){

        if(life<1){

           
           hearts[0].SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<GameController>().EndGame();

        }else if(life<2){

            
            hearts[1].SetActive(false);
            

        }else if(life<3){
            hearts[2].SetActive(false);
            

        }
    }
    public void checkLifeWin(){

        if(life==3){

          
           hearts[2].SetActive(true);
           Debug.Log(life);
        
        }else if(life==2){

           Debug.Log("aquii");
           
            hearts[1].SetActive(true);

        }
    }
   

}
