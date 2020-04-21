using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    //making variables for current position and edge positions
    //private SpriteRenderer mySpriteRenderer;
    private Vector3 myPosition;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;

    // Start is called before the first frame update
     void Awake() {
        //mySpriteRenderer = GetComponent<SpriteRenderer>();

    }//Awake 

    // Update is called once per frame
    void Update() {

        myPosition = transform.position;
        //setting turn around postions for enemy move
        pos1 = new Vector3(-2.634f, myPosition.y, myPosition.z);
        pos2 = new Vector3(2.634f, myPosition.y, myPosition.z);

        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

        //trying to flip enemy sprite not working
        /*if (myPosition.x == pos1.x) {
            if (mySpriteRenderer.flipX == true) {
                mySpriteRenderer.flipX = false;
            } else {
                mySpriteRenderer.flipX = true;
            }
        } else if (myPosition.x == pos2.x) {
            if (mySpriteRenderer.flipX == true) {
                mySpriteRenderer.flipX = false;
            } else {
                mySpriteRenderer.flipX = true;
            }
        }*/
    }//update


}//class
