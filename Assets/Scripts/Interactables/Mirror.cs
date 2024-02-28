using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Mirror : MonoBehaviour
{
    public bool player1InRange;
    public bool player2InRange;

    public bool player1Input;
    public bool player2Input;

    [SerializeField] public GameObject player1;
    [SerializeField] public GameObject player2;

    private void Start()
    {
        player1InRange = false;
        player2InRange = false;

        player1Input = false;
        player2Input = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + "is in range with " + this.name);
        if(collision.name == "Player 1")
        {
            Debug.Log("player1InRange = true");
            player1InRange = true;
        }
        if(collision.name == "Player 2")
        {
            Debug.Log("player2InRange = true");
            player2InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name + "has left range of " + this.name);
        if (collision.name == "Player 1")
        {
            Debug.Log("Player1InRange = false");
            Debug.Log("Player1Input = false");
            player1InRange = false;
            player1Input = false;
        }
        if (collision.name == "Player 2")
        {
            Debug.Log("Player2InRange = false");
            Debug.Log("Player2Input = false");
            player2InRange = false;
            player2Input = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Player1Interact") && player1InRange) 
        {
            player1Input = true;
            if (player1Input)
            {
                Debug.Log("Player 1 Interacting with Mirror");
            }
        }

        if (Input.GetButtonDown("Player2Interact") && player2InRange)
        {
            player2Input = true;
            if (player2Input)
            {
                Debug.Log("Player 2 Interacting with Mirror");
            }
        }
    }
}