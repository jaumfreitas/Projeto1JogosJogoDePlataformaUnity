using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    public float forcaPulo;
    public float velocidade;
    public bool chao;
    public bool vivo = true;
    void Start() {
 
    }
    void Update() {

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float movimento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movimento * velocidade, rigidbody.velocity.y);

        if(movimento < 0) {
            
            GetComponent<SpriteRenderer>().flipX = true;

        }else if( movimento > 0){

            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(movimento < 0 || movimento > 0){
            
            GetComponent<Animator>().SetBool("walking", true);
        
        }else {
           
            GetComponent<Animator>().SetBool("walking", false);
        }


        if(Input.GetKeyDown(KeyCode.Space) && chao){
            rigidbody.AddForce(new Vector2(0,forcaPulo));
        }

        if(chao) {
            GetComponent<Animator>().SetBool("jumping", false);
        }
        else {
            GetComponent<Animator>().SetBool("jumping", true);
        }
       
    }
    void OnCollisionEnter2D(Collision2D collision2D){

        if(collision2D.gameObject.CompareTag("plataformas")) {
            chao = true;
        }
        if(collision2D.gameObject.CompareTag("trampolim")) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f,12f);
        }
        if(collision2D.gameObject.CompareTag("minitrampolim")) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f,7f);
        }
        if(collision2D.gameObject.CompareTag("water")) {

            GetComponent<Animator>().SetBool("dying", true);
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
        if(collision2D.gameObject.CompareTag("npc")) {
           
           Collider2D[] colliders = new Collider2D[3];
           transform.Find("pes").gameObject.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), colliders);

            for( int i = 0; i < colliders.Length; i++){
                if(colliders[i] != null && colliders[i].gameObject.CompareTag("npc")){
                    Destroy(colliders[i].gameObject);
                }
            }
            Collider2D[] colliders2 = new Collider2D[3];
            transform.Find("corpo").gameObject.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), colliders2);
            
            for( int i = 0; i < colliders2.Length; i++){
                if(colliders2[i] != null && colliders2[i].gameObject.CompareTag("npc")){
                   GetComponent<Animator>().SetBool("dying", true);
                    Destroy(gameObject);
                    SceneManager.LoadScene(2);
                }
            }
        }
        if(collision2D.gameObject.CompareTag("youwin")) {
            
            SceneManager.LoadScene(3);
        }
    }

    void OnCollisionExit2D(Collision2D collision2D){
        if(collision2D.gameObject.CompareTag("plataformas")) {
            chao = false;
        }
    }

    //void Reload() {
    //    SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
    //}
}
