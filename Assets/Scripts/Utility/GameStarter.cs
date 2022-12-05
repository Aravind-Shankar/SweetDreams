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
        // Weird bug in Main menu where the level loader instance gets lost
        levelLoader = FindObjectOfType<LevelLoader>();

        levelLoader.StartGame();
    }

    public void StartTutorial()
    {
        levelLoader = FindObjectOfType<LevelLoader>();

        levelLoader.StartTutorial();
    }

}
