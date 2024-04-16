using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] bool playMusic = true;
    [SerializeField] int currentTrack;

    [SerializeField] AudioClip[] music;

    AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        if (playMusic) {
            musicSource.clip = music[currentTrack];
            musicSource.Play();

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playMusic) {
            if (musicSource.time >= musicSource.clip.length) {
                currentTrack++;

                if (currentTrack >= music.Length) {
                    currentTrack = 0;

                }

                musicSource.clip = music[currentTrack];

            }

            if (!musicSource.isPlaying) {
                musicSource.Play();

            }

        } else {
            musicSource.Stop();

        }
    }

}
