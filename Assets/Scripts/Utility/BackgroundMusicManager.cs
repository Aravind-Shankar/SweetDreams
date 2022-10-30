using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource bgm;
    public AudioClip barMusic;
    public AudioClip basementMusic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.y < -1) {
            if (bgm.clip != basementMusic) {
                bgm.clip = basementMusic;
                bgm.Play();
            }
        } else {
            if (bgm.clip != barMusic) {
                bgm.clip = barMusic;
                bgm.Play();
            }
        }
    }
}
