using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1;

    public void StartGame() {
        // weird bug: when restarting after a win, the transition never happens, no matter the order of these statements
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("Store"));
    }

    public void StartTutorial()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("Tutorial"));
    }

    IEnumerator LoadLevel(string level) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(level);
    }
}
