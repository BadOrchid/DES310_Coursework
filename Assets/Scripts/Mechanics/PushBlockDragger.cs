using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlockDragger : MonoBehaviour
{
    public string interactAxisName;

    private bool isDragging = false;

    private Rigidbody2D pushBlockRB;
    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(interactAxisName))
        {
            if (isDragging)
            {
                // If already dragging, release the block
                isDragging = false;
                pushBlockRB = null;
                Debug.Log("Player let go of block");
            }
            else
            {
                // Otherwise, check if player collider is touching a pushable block
                Collider2D[] colliders = Physics2D.OverlapCircleAll(playerGameObject.transform.position, 0.5f); // Adjust radius as needed

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("PushBlock"))
                    {
                        // Start dragging the block
                        isDragging = true;
                        pushBlockRB = collider.GetComponent<Rigidbody2D>();
                        break;
                    }
                }
                Debug.Log("Player grabbed block");
            }
        }

        // While dragging, update the block position
        if (isDragging && pushBlockRB != null)
        {
            // Calculate the position where the block should be dragged to (e.g., in front of the player)
            Vector2 newPosition = playerGameObject.transform.position + (playerGameObject.transform.right * 1.5f); // Adjust 1.5f as needed

            // Move the block to the new position
            pushBlockRB.MovePosition(newPosition);
        }
    
    }
}
