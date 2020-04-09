using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D myBody;

    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public float normalPush = 10f;
    [SerializeField] public float extraPush = 14f;

    private bool initialPush;
    private int pushCount;
    private bool playerDied;

    
    void Awake() {

        myBody = GetComponent<Rigidbody2D>();

    }
    
    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D target) {
        
        //if collides with object with ExtraPush tag, give boost
        if(target.tag == "ExtraPush") {

            if(!initialPush) {

                initialPush = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);

                target.gameObject.SetActive(false);

                // Sound manager
                
                // exit from on trigger enter because of initial push
                return;
            }
        }

    } // on trigger enter






} //class