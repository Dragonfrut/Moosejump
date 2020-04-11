﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

    private bool followPlayer;

    public float min_Y_Threshold = -2.6f;

    // Start is called before the first frame update
    void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        Follow();
    }

    void Follow() {

        //if player position below camera, do not follow
        if (target.position.y < (transform.position.y - min_Y_Threshold)) {
            followPlayer = false;
        }

        //if player position above camera, follow
        if (target.position.y > transform.position.y) {
            followPlayer = true;
        }

        //camera follows player
       if (followPlayer) {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
            
    
    }


}//class