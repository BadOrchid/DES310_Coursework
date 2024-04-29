using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPillar : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite completeSprite;

    [SerializeField] public bool waitForAllComplete = false;

    [SerializeField] float radius = 0.7f;
    [SerializeField] PlayerType type = PlayerType.None;

    List<TwoPlayerControls> players;

    PlayerType colliderType;

    public int spritesIndex = 0;
    public bool complete = false;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<TwoPlayerControls>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {
        if (GetPlayersInRange()) {
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
        foreach (TwoPlayerControls player in players) {
            // Checks if player is same type as pillar
            if (player.type == type) {
                if ((player.type == PlayerType.Human && Input.GetButtonDown("Player1Interact")) || (player.type == PlayerType.Ghost && Input.GetButtonDown("Player2Interact"))) {
                    player.animator.SetTrigger("isRotating");

                    spritesIndex++;

                    if (spritesIndex == sprites.Length) {
                        spritesIndex = 0;

                    }

                }

            }

        }

    }

    // Checks if Player is in range
    bool GetPlayersInRange() {
        // Gets all colliders the circle overlaps
        Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * radius);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        players.Clear();

        // Checks if any of the colliders is a player
        foreach (Collider2D collider in colliders) {
            TwoPlayerControls player = collider.transform.GetComponent<TwoPlayerControls>();
            if (player) {
                // If player is not already in list
                if (!players.Contains(player)) {
                    players.Add(player);

                }

            }

        }

        // If players in range
        if (players.Count > 0) {
            return true;

        }
        else {
            return false;

        }

    }

}