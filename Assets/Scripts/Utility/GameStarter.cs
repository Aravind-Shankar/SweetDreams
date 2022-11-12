using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    LevelLoader levelLoader;

    private void Awake() {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void StartGame() {
        levelLoader.StartGame();
    }

}
