using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    //plateform variables
    public static PlatformSpawner instance;
    //holds the prefabs for platform objects
    [SerializeField] private GameObject left_Platform, right_Platform;
    //platform spawn range on left and right sides
    private float left_X_Min = -4.4f, left_X_Max = -2.8f, right_X_Min = 4.4f, right_X_Max = 2.8f;
    //how far platforms spawn vertically from eachother
    private float y_Threshold = 2.6f;
    private float last_Y;

    //how many platforms per spawn
    public int spawn_Count = 8;
    //to determine spawn left or right plateform
    private int platform_Spawned;
    //object holder to spawn plateform under for less object clutter
    [SerializeField] private Transform platform_Parent;

    // more variables to spawn bird enemy
    [SerializeField]
    private GameObject bird;
    public float bird_Y = 5f;
    private float bird_X_Min = -2.3f, bird_X_Max = 2.3f;

    void Awake() {
        if (instance == null)
            instance = this;
    }//awake

    void Start() {

        last_Y = transform.position.y;
        SpawnPlatforms();

    }//start

    //spawns platforms in semi random ranges 
    public void SpawnPlatforms() {

        Vector2 temp = Vector2.zero;
        GameObject newPlatform = null;

        //where to choose wether to spawn plat on left or right side
        for (int i = 0; i < spawn_Count; i++) {

            temp.y = last_Y;

            // if we have even number
            if((platform_Spawned % 2) == 0) {
                temp.x = Random.Range(right_X_Min, right_X_Max);
                newPlatform = Instantiate(left_Platform, temp, Quaternion.identity);

            } else {
                // if we have odd number
                temp.x = Random.Range(left_X_Min, left_X_Max);
                newPlatform = Instantiate(right_Platform, temp, Quaternion.identity);

            }

            //spawns the new plateform in the holder object
            newPlatform.transform.parent = platform_Parent;

            last_Y += y_Threshold;
            platform_Spawned++;

        }

        //randomly spawns a bird
        if(Random.Range(0, 2) > 0) {
            SpawnBird();
        }

    } // spawn platforms

    //spawns birds 
    void SpawnBird() {

        Vector2 temp = transform.position;
        temp.x = Random.Range(bird_X_Min, bird_X_Max);
        temp.y += bird_Y;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platform_Parent;

    }//spawn birds

} // class

