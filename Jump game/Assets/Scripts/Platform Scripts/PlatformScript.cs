using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    //holds the banana prefabs for spawner
    [SerializeField]
    private GameObject one_Banana, bananas;

    //holds spawner object
    [SerializeField]
    private Transform spawn_Point;

    // Start is called before the first frame update
    void Start() {

        GameObject newBanana = null;

        //randomly spawns one banana or bananas on a platform
        if(Random.Range(0, 10) > 3) {

            newBanana = Instantiate(one_Banana, spawn_Point.position, Quaternion.identity);

        } else {

            newBanana = Instantiate(bananas, spawn_Point.position, Quaternion.identity);

        }

        newBanana.transform.parent = transform;

    }//start


} // class



