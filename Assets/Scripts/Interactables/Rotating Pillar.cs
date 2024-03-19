using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPillar : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite completeSprite;

    [SerializeField] float radius = 0.7f;
    [SerializeField] PlayerType type = PlayerType.None;

    PlayerType colliderType;

    public int spritesIndex = 0;
    public bool complete = false;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {
        if (PlayerInRange()) {
            UserInput();

        }

        // If all pillars are in correct state
        if (complete) {
            spriteRenderer.sprite = completeSprite;

        // Else render current sprite
        } else {
            spriteRenderer.sprite = sprites[spritesIndex];

        }

    }

    void UserInput() {
        // If Player is Human
        if (colliderType == PlayerType.Human) {

            // Move to next angle when Interact is pressed
            if (Input.GetButtonDown("Player1Interact")) {
                spritesIndex++;

                if (spritesIndex == sprites.Length) {
                    spritesIndex = 0;

                }

            }

            // If Player is Ghost
        }
        else if (colliderType == PlayerType.Ghost) {

            // Move to next angle when Interact is pressed
            if (Input.GetButtonDown("Player2Interact")) {
                spritesIndex++;

                if (spritesIndex == sprites.Length) {
                    spritesIndex = 0;

                }

            }

        }

    }

    // Checks if Player is in range
    bool PlayerInRange() {
        // Gets all colliders the circle overlaps
        Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * radius);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        // Checks if any of the colliders is a player
        foreach (Collider2D collider in colliders) {
            TwoPlayerControls player = collider.transform.GetComponent<TwoPlayerControls>();
            if (player) {

                // Sets the colliderType to Human or Ghost
                colliderType = player.type;

                // If this scripts type matches the colliders type, Player is in range
                if (colliderType == type || type == PlayerType.None) {

                    Debug.Log("Player in range");

                    return true;

                }

            }

        }

        return false;

    }

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    //Checks when the Player is in near
    //    if (this.CompareTag(collision.tag)) {
    //        playerInRange = true;
    //        colliderType = collision.GetComponent<TwoPlayerControls>().type;
    //        Debug.Log(this.name + " is in range");

    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision) {
    //    // Checks when the Player leaves
    //    if (this.CompareTag(collision.tag)) {
    //        playerInRange = false;
    //        Debug.Log(this.name + " is out of range");

    //    }
    //}

}
