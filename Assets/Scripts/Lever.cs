using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] PlayerType type = PlayerType.None;
    [SerializeField] public bool on = false;
    [SerializeField] Sprite offSprite;
    [SerializeField] Sprite onSprite;

    SpriteRenderer spriteRenderer;

    bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (on) {
            onSprite = spriteRenderer.sprite;

        } else { 
            offSprite = spriteRenderer.sprite;

        }

    }

    // Update is called once per frame
    void Update()
    {
       if (playerInRange) {
            UserInput();

        }


    }

    void ChangeSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;

    }

    void UserInput() {
        if (type == PlayerType.None) {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O)) {
                on ^= true;

            }

        }
        else if (type == PlayerType.Human) {
            if (Input.GetKeyDown(KeyCode.E)) {
                on ^= true;

            }

        }
        else if (type == PlayerType.Ghost) {
            if (Input.GetKeyDown(KeyCode.O)) {
                on ^= true;

            }

        }

        // Updates sprites image
        if (on) {
            ChangeSprite(onSprite);

        }
        else {
            ChangeSprite(offSprite);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Checks when the Player is in near
        if (collision.tag == "Player") {
            playerInRange = true;
            Debug.Log("I am in range");

        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Checks when the Player leaves
        if (collision.tag == "Player") {
            playerInRange = false;
            Debug.Log("I am out of range");

        }

    }

}
