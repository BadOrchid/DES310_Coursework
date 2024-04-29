using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tile;

public class Chair : MonoBehaviour
{

    [SerializeField] float radius = 0.5f;
    [SerializeField] bool isFacingLeft;
    [SerializeField] Vector2 humanOffset;
    [SerializeField] Vector2 ghostOffset;

    bool playerInChair = false;

    List<TwoPlayerControls> players;
    TwoPlayerControls satPlayer;

    Vector3 playerStandingPos;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<TwoPlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {

        // Get players in range if no player is in the chair
        if (!playerInChair) {
            GetPlayersInRange();

        }

        UserInput();


    }


    // Checks if Human Player is in range
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

    void UserInput() {
        // If player is sitting, stand up
        if (playerInChair) {
            if ((satPlayer.type == PlayerType.Human && Input.GetButtonDown("Player1Interact")) || (satPlayer.type == PlayerType.Ghost && Input.GetButtonDown("Player2Interact"))) {
                satPlayer.animator.SetBool("isSitting", false);
                playerInChair = false;

                Collider2D[] colliders = satPlayer.GetComponents<Collider2D>();

                foreach (Collider2D collider in colliders) {
                    collider.enabled = true;

                }

                satPlayer.transform.position = playerStandingPos;

            }

        }
        else {
            foreach (TwoPlayerControls player in players) {
                // Toggle sit on chair
                if ((player.type == PlayerType.Human && Input.GetButtonDown("Player1Interact")) || (player.type == PlayerType.Ghost && Input.GetButtonDown("Player2Interact"))) {
                    // If player is standing
                    if (!player.animator.GetBool("isSitting")) {
                        // If chair is empty
                        if (!playerInChair) {
                            playerStandingPos = player.transform.position;

                            Collider2D[] colliders = player.GetComponents<Collider2D>();

                            foreach (Collider2D collider in colliders) {
                                collider.enabled = false;

                            }

                            if (player.type == PlayerType.Human) {
                                player.transform.position = transform.position + Quaternion.Euler(0, 0, 60) * new Vector2(humanOffset.x * transform.localScale.x, humanOffset.y * transform.localScale.y);

                            }
                            else {
                                player.transform.position = transform.position + Quaternion.Euler(0, 0, 60) * new Vector2(ghostOffset.x * transform.localScale.x, ghostOffset.y * transform.localScale.y);

                            }

                            Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
                            rigidbody2D.velocity = Vector3.zero;
                            player.animator.SetFloat("speed", 0.0f);

                            player.animator.SetBool("isFacingLeft", isFacingLeft);
                            player.animator.SetBool("isSitting", true);
                            playerInChair = true;
                            satPlayer = player;

                        }

                    }

                }

            }

        }

    }

}