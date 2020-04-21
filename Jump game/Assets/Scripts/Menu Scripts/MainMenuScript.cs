using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public void PlayGame () {
        //starts the game
        SceneManager.LoadScene("Gameplay");
    }//play 

    public void QuitGame() {
        //quits the game
        Application.Quit();
    }//quit
}
