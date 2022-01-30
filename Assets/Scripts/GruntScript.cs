using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public float LastShoot;
    public GameObject BulletPrefab;
    private int Health = 1;

    
    void Start() {
      
        
     }


    void Update()
    {
        
        
        /*Queremos que Grunt siempre este mirando a John.
        Para eso cogemos la posición de John y la de Grunt y si la diferencia
        es un número positivo mira a la derecha y negativo mira a la izquierda*/

        if (John == null)
        {
            return;
        }
        else
        {
            Vector3 direction = John.transform.position - transform.position;
            if (direction.x >= 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
               
            }
            else
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
               
                
            }

            /*Distancia que esta Grunt de John en valor absoluto
              A menos de 1 metro -> diparar*/
            float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

            if (distance < 1.0f && Time.time > LastShoot + 0.25f)
            {
                Shoot();
                LastShoot = Time.time;

            }
        }


    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Destroy(gameObject);
            
        }
    }

}
