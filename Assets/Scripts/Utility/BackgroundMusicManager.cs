using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource bgm;
    public AudioClip barMusic;
    public AudioClip basementMusic;
    public GameObject susBar;
    private float susVal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        susVal = susBar.GetComponent<SusBar>().GetSus();
        bgm.volume = 0.1f + susVal / 300;
        if (susVal < 50) {
            bgm.pitch = 1f;
        } else if (susVal > 75) {
            bgm.pitch = 1.4f;
        } else if (susVal > 90) {
            bgm.pitch = 1.6f;
        } else {
            bgm.pitch = 1.2f;
        }
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
