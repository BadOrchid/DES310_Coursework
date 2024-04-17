using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{

    [SerializeField] PlayerType type = PlayerType.None;
    [SerializeField] public bool on = false;

    [Range(0, 1)][SerializeField] float sfxVolume = 1.0f;
    [SerializeField] AudioClip sfx;

    public bool freeze = false;

    PlayerType colliderType;

    Animator animator;

    AudioSource audioSource;

    bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sfx;
        audioSource.volume = sfxVolume;

    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze) {
            if (playerInRange) {
                UserInput();

            }

            animator.SetBool("playerInRange", playerInRange);

        } else {
            animator.SetBool("playerInRange", false);

        }

    }


    void UserInput() {
        // Checks if the colliding Player is Human and this Lever is of type None or Human - - - The && might not be necessary (will always be true due to OnTriggerEnter2D?)
        if (colliderType == PlayerType.Human && (type == PlayerType.None || type == PlayerType.Human)) {
            if (Input.GetButtonDown("Player1Interact")) {
                Invoke("FlipLever", audioSource.clip.length);
                
                animator.SetBool("on", !on);

                PlaySfx();

                Debug.Log("Human flipped " + this.name);

            }

        }
        // Checks if the colliding Player is Ghost and this Lever is of type None or Ghost
        else if (colliderType == PlayerType.Ghost && (type == PlayerType.None || type == PlayerType.Ghost)) {
            if (Input.GetButtonDown("Player2Interact")) {
                Invoke("FlipLever", audioSource.clip.length);

                animator.SetBool("on", !on);

                PlaySfx();

                Debug.Log("Ghost flipped " + this.name);

            }

        }

    }

    void FlipLever() {
        on ^= true;

    }

    void PlaySfx() {
        audioSource.Play();

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Checks when the Player is in near
        if (this.CompareTag(collision.tag)) {
            playerInRange = true;
            colliderType = collision.GetComponent<TwoPlayerControls>().type;
            Debug.Log(this.name + " is in range");

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Checks when the Player leaves
        if (this.CompareTag(collision.tag)) {
            playerInRange = false;
            Debug.Log(this.name + " is out of range");

        }
    }

}
