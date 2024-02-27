using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwapper : MonoBehaviour
{
    [SerializeField] public GameObject player1;
    [SerializeField] public GameObject player2;

    public Mirror mirror1;
    public Mirror mirror2;

    private void SwapPlayerPositions()
    {
        // Check if both player GameObjects are available
        if (player1 != null && player2 != null)
        {
            // Store the position of player1
            Vector3 temp = player1.transform.position;

            // Set the position of player1 to player2's position
            player1.transform.position = player2.transform.position;

            // Set the position of player2 to the stored position
            player2.transform.position = temp;
        }
        else
        {
            Debug.LogError("One or both player GameObjects are missing!");
        }
    }

    private void Update()
    {
        if(mirror1.player1Input == true && mirror2.player2Input == true)
        { 
            SwapPlayerPositions();
        }
        else if(mirror2.player1Input == true && mirror1.player2Input == true) 
        {
            SwapPlayerPositions();
        }
    }
}
