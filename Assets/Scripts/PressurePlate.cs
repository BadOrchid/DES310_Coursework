using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] PlayerType type = PlayerType.None;
    [SerializeField] public bool on = false;
    [SerializeField] Sprite offSprite;
    [SerializeField] Sprite onSprite;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (on) {
            onSprite = spriteRenderer.sprite;

        }
        else {
            offSprite = spriteRenderer.sprite;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Checks when the pressure plate is pressed
        if (collision.tag == "Block") {
            on = true;
            Debug.Log("Pressed");

        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Checks if the pressure plate has been unpressed
        if (collision.tag == "Block") {
            on = false;
            Debug.Log("Unpressed");

        }

    }

}
