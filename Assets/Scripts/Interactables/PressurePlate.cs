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

    void ChangeSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Checks when the pressure plate is pressed
        if (collision.tag == "Block") {
            PlayerType otherType = collision.GetComponent<PushBlock>().type;
            if (otherType == type || type == PlayerType.None) {
                on = true;
                ChangeSprite(onSprite);
                Debug.Log(this.name + " Pressed");

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Checks if the pressure plate has been unpressed
        if (collision.tag == "Block") {
            on = false;
            ChangeSprite(offSprite);
            Debug.Log("Unpressed");

        }

    }

}
