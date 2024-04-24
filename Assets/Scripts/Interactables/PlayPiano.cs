using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tile;

public class PlayPiano : MonoBehaviour
{
    [Range(0, 1)][SerializeField] float sfxVolume = 1.0f;
    [SerializeField] AudioClip sfx;

    bool player1InRange;
    bool player2InRange;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sfx;
        audioSource.volume = sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        PlayChord();
    }

    void PlayChord() 
    { 
        if(Input.GetButtonDown("Player1Interact") && player1InRange)
        {
            audioSource.Play();
            Debug.Log("Human played " + this.name);
        }
        if (Input.GetButtonDown("Player2Interact") && player2InRange)
        {
            audioSource.Play();
            Debug.Log("Ghost played " + this.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Human"))
        {
            player1InRange = true;
            Debug.Log(this.name + " is in range");
        }
        if (collision.CompareTag("Ghost"))
        {
            player2InRange = true;
            Debug.Log(this.name + " is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Human")
        {
            player1InRange = false;
            Debug.Log(this.name + " is in range");
        }
        if (collision.tag == "Ghost")
        {
            player2InRange = false;
            Debug.Log(this.name + " is in range");
        }
    }
}
