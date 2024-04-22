using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateFacing : MonoBehaviour {

    [SerializeField] float faceByDefault = 0.0f;
    [SerializeField] float radius = 0.5f;
    [SerializeField] PlayerType type = PlayerType.None;

    PlayerType colliderType;

    int[] angles = { 0, 60, 90, 120, 180, 240, 270, 300 };
    int angleIndex = 0;

    public Quaternion rotation;

    // Start is called before the first frame update
    void Start() {
        rotation = Quaternion.Euler(0, 0, faceByDefault);

    }

    // Update is called once per frame
    void Update() {

        if (PlayerInRange()) {
            UserInput();

        }

    }

    // Checks if Human Player is in range
    bool PlayerInRange() {
        // Gets all colliders the circle overlaps
        //Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * radius);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        // Checks if any of the colliders is a player
        foreach (Collider2D collider in colliders) {
            TwoPlayerControls player = collider.transform.GetComponent<TwoPlayerControls>();
            if (player) {

                // Sets the colliderType to Human or Ghost
                colliderType = player.type;

                // If this scripts type matches the colliders type, Player is in range
                if (colliderType == type || type == PlayerType.None) {
                    return true;

                }

            }

        }

        return false;

    }

    void UserInput() {
        // If Player is Human
        if (colliderType == PlayerType.Human) {

            // Move to next angle when Interact is pressed
            if (Input.GetButtonDown("Player1Interact")) {
                angleIndex++;

                if (angleIndex == angles.Length) {
                    angleIndex = 0;

                }

                // Calculate Rotation
                rotation = Quaternion.Euler(0, 0, angles[angleIndex]);

            }

            // If Player is Ghost
        }
        else if (colliderType == PlayerType.Ghost) {

            // Move to next angle when Interact is pressed
            if (Input.GetButtonDown("Player2Interact")) {
                angleIndex++;

                if (angleIndex == angles.Length) {
                    angleIndex = 0;

                }

                // Calculate Rotation
                rotation = Quaternion.Euler(0, 0, angles[angleIndex]);

            }

        }

    }

}