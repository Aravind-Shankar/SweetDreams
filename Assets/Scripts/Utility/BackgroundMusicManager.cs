using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public GameObject player;
    private AudioSource shopAudio;
    private AudioSource basementAudio;
    //public AudioClip barMusic;
    //public AudioClip basementMusic;
    public GameObject susBar;
    private float susVal;
    private float vol;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        AudioSource[] audioSources = GetComponents<AudioSource>();
        shopAudio = audioSources[0];
        basementAudio = audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {
        susVal = susBar.GetComponent<SusBar>().GetSus();
        vol = 0.1f + susVal / 300;
        if (susVal >= 100) {
            shopAudio.Stop();
            basementAudio.Stop();
        } else if (susVal < 50) {
            shopAudio.pitch = 1f;
            basementAudio.pitch = 1f;
        } else if (susVal > 75) {
            shopAudio.pitch = 1.4f;
            basementAudio.pitch = 1.4f;
        } else {
            shopAudio.pitch = 1.2f;
            basementAudio.pitch = 1.2f;
        }
        float posDif = (7 + player.transform.position.y) / 7;
        shopAudio.volume = vol * posDif;
        basementAudio.volume = vol * (1 - posDif);
        /**if (player.transform.position.y < -1) {
            if (shopAudio.clip != basementMusic) {
                shopAudio.clip = basementMusic;
                shopAudio.Play();
            }
        } else {
            if (shopAudio.clip != barMusic) {
                shopAudio.clip = barMusic;
                shopAudio.Play();
            }
        }**/
    }
}
