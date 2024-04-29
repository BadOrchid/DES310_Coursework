using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLight : MonoBehaviour
{
    [SerializeField] public bool on = false;
    [SerializeField] Sprite offSprite;
    [SerializeField] Sprite onSprite;

    SpriteRenderer spriteRenderer;

    bool player1InRange = false;
    bool player2InRange = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (on)
        {
             spriteRenderer.sprite = onSprite;

        }
        else
        {
           spriteRenderer.sprite = offSprite;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1InRange)
        {
            if (Input.GetButtonDown("Player1Interact"))
            {
                if (on)
                {
                    Debug.Log("Light switched on");
                    spriteRenderer.sprite = offSprite;
                    on = false;
                }
                else
                {
                    Debug.Log("Light Switched off");
                    spriteRenderer.sprite = onSprite;
                    on = true;
                }
            }
        }

        if(player2InRange)
        {
            if (Input.GetButtonDown("Player2Interact"))
            {
                if (on)
                {
                    Debug.Log("Light switched on");
                    spriteRenderer.sprite = offSprite;
                    on = false;
                }
                else
                {
                    Debug.Log("Light Switched off");
                    spriteRenderer.sprite = onSprite;
                    on = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player 1")
        {
            Debug.Log("Player 1 in Range");
            player1InRange = true;
        }
        if(collision.name == "Player 2")
        {
            Debug.Log("Player 2 in Range");
            player2InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player 1")
        {
            Debug.Log("Player 1 out of Range");
            player1InRange = false;
        }

        if(collision.name == "Player 2")
        {
            Debug.Log("Player 2 out of Range");
            player2InRange = false;
        }
    }
}
