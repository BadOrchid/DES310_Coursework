using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    [SerializeField] bool playerInRange = false;
    [SerializeField] float radius = 0.5f;
    [SerializeField] PlayerType type = PlayerType.None;

    PlayerType colliderType;

    int[] angles = { 0, 60, 90, 120, 180, 240, 270, 300 };
    int angleIndex = 0;

    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerInRange = PlayerInRange();
        

        if (playerInRange) {
            UserInput();

        }

        rotation = Quaternion.Euler(0, 0, angles[angleIndex]);

        transform.rotation = rotation;


    }

    // Checks if Human Player is in range
    bool PlayerInRange() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        //Debug.DrawRay(transform.position, new Vector3(1, 0, 0) * radius);

        foreach (Collider2D collider in colliders) {
            TwoPlayerControls player = collider.transform.GetComponent<TwoPlayerControls>();
            if (player) {

                colliderType = player.type;

                if (colliderType == type || type == PlayerType.None) {
                    return true;

                }

            }

        }

        return false;

    }

    void UserInput() {
        if (colliderType == PlayerType.Human) {

            if (Input.GetButtonDown("Player1Interact")) {
                angleIndex++;

                if (angleIndex == angles.Length) {
                    angleIndex = 0;

                }

            }

        } else if (colliderType == PlayerType.Ghost) {

            if (Input.GetButtonDown("Player2Interact")) {
                angleIndex++;

                if (angleIndex == angles.Length) {
                    angleIndex = 0;

                }

            }

        }

    }

}
