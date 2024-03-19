using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class PushBlockDragger : MonoBehaviour
{
    public string interactAxisName;

    [SerializeField] private bool isDragging = false;
    [SerializeField] private bool isTouching = false;
    [SerializeField] private bool isMatching = false;

    private Rigidbody2D pushBlockRB;
    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.name + " is touching " + collision.name);

        pushBlockRB = collision.GetComponent<Rigidbody2D>();

        if ((this.name == "Human") && (collision.name == "Push Block - Human"))
        {
            isMatching = true;
        }
        else if ((this.name == "Ghost") && (collision.name == "Push Block - Ghost"))
        {
            isMatching = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(this.name + " is no longer touching " + collision.name);
        
        isMatching = false;
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
                if (isMatching)
                {
                    isDragging = true;
                    Debug.Log("Player grabbed block");
                }
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
