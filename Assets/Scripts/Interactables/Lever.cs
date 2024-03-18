using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{

    [SerializeField] PlayerType type = PlayerType.None;
    [SerializeField] public bool on = false;

    PlayerType colliderType;

    Animator animator;

    bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       if (playerInRange) {
            UserInput();

        }

        animator.SetBool("playerInRange", playerInRange);
        animator.SetBool("on", on);

    }


    void UserInput() {
        // Checks if the colliding Player is Human and this Lever is of type None or Human - - - The && might not be necessary (will always be true due to OnTriggerEnter2D?)
        if (colliderType == PlayerType.Human && (type == PlayerType.None || type == PlayerType.Human)) {
            if (Input.GetButtonDown("Player1Interact")) {
                on ^= true;
                Debug.Log("Human flipped " + this.name);

            }

        }
        // Checks if the colliding Player is Ghost and this Lever is of type None or Ghost
        else if (colliderType == PlayerType.Ghost && (type == PlayerType.None || type == PlayerType.Ghost)) {
            if (Input.GetButtonDown("Player2Interact")) {
                on ^= true;
                Debug.Log("Ghost flipped " + this.name);

            }

        }

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
