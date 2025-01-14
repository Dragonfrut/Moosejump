﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    //the background
    private GameObject[] bgs;
    private float height;
    private float highest_Y_Pos;

    void Awake() {
        //find all the backgrounds
        bgs = GameObject.FindGameObjectsWithTag("BG");
    }

    void Start() {

        //get the height of the bg
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;
        //the hightest y position 
        highest_Y_Pos = bgs[0].transform.position.y;
        //compares y's as we go and sets it
        for(int i = 1; i < bgs.Length; i++) {

            if (bgs[i].transform.position.y > highest_Y_Pos)
                highest_Y_Pos = bgs[i].transform.position.y;

        }

    }

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "BG") {
        
            // we collided with the highest Y BG
            if(target.transform.position.y >= highest_Y_Pos) {

                Vector3 temp = target.transform.position;
                //after we hit the top BG we spawn more
                for(int i = 0; i < bgs.Length; i++) { 
                 
                    // if the BG at "i" index is NOT active in the hierarchy
                    if(!bgs[i].activeInHierarchy) {

                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        highest_Y_Pos = temp.y;

                    }

                }

            }

        }

    } // on trigger enter


} // class




