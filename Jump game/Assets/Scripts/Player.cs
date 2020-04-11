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
    private string xtrPush = "ExtraPush";
    private string normPush = "NormalPush";
    
    void Awake() {

        myBody = GetComponent<Rigidbody2D>();

    }
    
    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }

    void Move() {
        
        if (playerDied) {
            return;
        }

        if (Input.GetAxisRaw("Horizontal") > 0) {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    }//Player movement

    void OnTriggerEnter2D(Collider2D target) {

        if (playerDied)
            return;

        if (target.tag == xtrPush) {

            if (!initialPush) {

                initialPush = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);

                target.gameObject.SetActive(false);



                // exit from the on trigger enter because of initial push
                return;
            } // initial push

            // outside of the initial push

        } // because of the initial push

        if (target.tag == normPush) {

            myBody.velocity = new Vector2(myBody.velocity.x, normalPush);

            target.gameObject.SetActive(false);

            pushCount++;

        }

        if (target.tag == xtrPush) {

            myBody.velocity = new Vector2(myBody.velocity.x, extraPush);

            target.gameObject.SetActive(false);

            pushCount++;

        }

        if (pushCount == 2) {

            pushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();

        }


    }



 } //class