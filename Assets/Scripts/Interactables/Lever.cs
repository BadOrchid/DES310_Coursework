using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{

    [SerializeField] PlayerType type = PlayerType.None;
    [SerializeField] public bool on = false;

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
        if (type == PlayerType.Human && this.name == "Lever - Human") {
            if (Input.GetKeyDown(KeyCode.E)) {
                on ^= true;
                Debug.Log("Human flipped " + this.name);

            }

        }
        else if (type == PlayerType.Ghost && this.name == "Lever - Ghost") {
            if (Input.GetKeyDown(KeyCode.O)) {
                on ^= true;
                Debug.Log("Ghost flipped " + this.name);

            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        //Checks when the Player is in near
        if (this.CompareTag(collision.tag)) {
            playerInRange = true;
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
