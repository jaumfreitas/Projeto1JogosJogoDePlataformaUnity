using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {

    public bool colidde = false;

    public float move = -2;
    void Start(){
        
    }

    void Update(){
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
        if(colidde){
            move *= -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            colidde = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D){

        if(collision2D.gameObject.CompareTag("plataformas")) {
           
            colidde = true;
        }
        if(collision2D.gameObject.CompareTag("kill")) {
            
                Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision2D){
        
        if(collision2D.gameObject.CompareTag("plataformas")) {
            colidde = false;
        }
    }
}
