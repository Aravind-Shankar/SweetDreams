using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    public void Quit() {
        Debug.Log("Exit Game");

    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
