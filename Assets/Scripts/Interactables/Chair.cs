using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tile;

public class Chair : MonoBehaviour
{

    [SerializeField] float radius = 0.5f;
    [SerializeField] bool isFacingLeft;
    [SerializeField] Vector2 offset;

    bool playerInChair = false;

    List<TwoPlayerControls> players;

    Vector3 playerStandingPos;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<TwoPlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerInRange()) {
            UserInput();

        }


    }


    // Checks if Human Player is in range
    bool PlayerInRange() {
        // Gets all colliders the circle overlaps
        //Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * radius);
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
        foreach (TwoPlayerControls player in players) {
            // Toggle sit on chair
            if ((player.type == PlayerType.Human && Input.GetButtonDown("Player1Interact")) || (player.type == PlayerType.Ghost && Input.GetButtonDown("Player2Interact"))) {
                // If player is sitting, stand up
                if (player.animator.GetBool("isSitting")) {
                    player.animator.SetBool("isSitting", false);
                    playerInChair = false;

                    player.transform.position = playerStandingPos;

                }
                // If player is standing
                else {
                    // If chair is empty
                    if (!playerInChair) {
                        playerStandingPos = player.transform.position;

                        player.transform.position = transform.position + Quaternion.Euler(0, 0, 60) * new Vector2(offset.x * transform.localScale.x, offset.y * transform.localScale.y);

                        player.animator.SetBool("isFacingLeft", isFacingLeft);
                        player.animator.SetBool("isSitting", true);
                        playerInChair = true;

                    }

                }

            }

        }

    }

}
