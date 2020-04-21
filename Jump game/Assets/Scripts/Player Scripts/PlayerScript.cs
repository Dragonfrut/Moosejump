using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D myBody;
    //movement variables
    public float move_Speed = 2f;
    public float tilt;
    public float normal_Push = 10f;
    public float extra_Push = 14f;
    //push at start of game
    private bool initial_Push;
    private int push_Count;

    private bool player_Died;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }

    void Move() {

        if (player_Died)
            return;
        /*
        if (Input.GetAxisRaw("Horizontal") > 0) {

            myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);

        } else if(Input.GetAxisRaw("Horizontal") < 0) {

            myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);

        }
        */
        tilt = Input.acceleration.x * move_Speed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.635f, 2.635f), transform.position.y);
        myBody.velocity = new Vector2(tilt, myBody.velocity.y);
        
    } // player movement

    void OnTriggerEnter2D(Collider2D target) {

        if (player_Died)
            return;
        //push from the first default bananas
        if (target.tag == "ExtraPush") { 

            if(!initial_Push) {

                initial_Push = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);

                target.gameObject.SetActive(false);

                SoundManager.instance.JumpSoundFX();

                // exit from the on trigger enter because of initial push
                return;
            } // initial push
        }

        // outside of the initial push
        // push from one banana 
        if (target.tag == "NormalPush") {

            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);

            target.gameObject.SetActive(false);

            push_Count++;

            ScoreScript.scoreValue += 1;

            SoundManager.instance.JumpSoundFX();

        }

        //push from bananas
        if (target.tag == "ExtraPush") {

            myBody.velocity = new Vector2(myBody.velocity.x, extra_Push);

            target.gameObject.SetActive(false);

            push_Count++;

            ScoreScript.scoreValue += 2;

            SoundManager.instance.JumpSoundFX();

        } 

        if(push_Count == 2) {

            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();

        }

        //what happens when player falls/hits bird
        if(target.tag == "FallDown" || target.tag == "Bird") {

            player_Died = true;

            ScoreScript.scoreValue = 0;

            SoundManager.instance.GameOverSoundFX();

            GameManager.instance.RestartGame();
        }

    } // on trigger enter


} // class


