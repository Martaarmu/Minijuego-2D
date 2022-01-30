using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScene01 : MonoBehaviour
{
    public Transform[] puntosMov;
    public float velocidad;
    private int i =0;
    private int Health = 1;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMov[i].transform.position, velocidad*Time.deltaTime);
        
        if(Vector2.Distance(transform.position, puntosMov[i].transform.position)< 0.1f){

            if(puntosMov[i] != puntosMov[puntosMov.Length -1]){
                i++;
            }else{
                i=0;
            }
        }
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
