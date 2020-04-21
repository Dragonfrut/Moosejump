using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    void Awake() {
        if (instance == null)
            instance = this;
    }//awake

    public void RestartGame() {
        Invoke("LoadGameplay", 2f);
    }//restart

    void LoadGameplay() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }//load



} // class




