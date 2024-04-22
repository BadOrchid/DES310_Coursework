using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    enum PlateType { Block, Pillar, Player, Either }

    [SerializeField] PlayerType playerType = PlayerType.None;
    [SerializeField] PlateType plateType = PlateType.Either;
    [SerializeField] public bool on = false;
    [SerializeField] Sprite offSprite;
    [SerializeField] Sprite onSprite;

    [Range(0, 1)][SerializeField] float sfxVolume = 1.0f;
    [SerializeField] AudioClip sfx;

    SpriteRenderer spriteRenderer;

    AudioSource audioSource;

    bool lastState;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sfx;
        audioSource.volume = sfxVolume;

        if (on) {
            onSprite = spriteRenderer.sprite;

        }
        else {
            offSprite = spriteRenderer.sprite;

        }

        lastState = on;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void ChangeSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Checks if collided with a Push Block when the Pressure Plate is a Block or Either type
        if ((plateType == PlateType.Block || plateType == PlateType.Either) && collision.tag == "Block") {
            PlayerType otherType = collision.GetComponent<PushBlock>().type;
            if (otherType == playerType || playerType == PlayerType.None) {
                lastState = on;
                on = true;

                if (lastState != on) {
                    audioSource.Play();

                }

                ChangeSprite(onSprite);
                Debug.Log(this.name + " Pressed by " + collision.tag);

            }

        //else if ((plateType == PlateType.Pillar || plateType == PlateType.Either) && collision.tag == "Pillar") {
        //        PlayerType oppType = collision.GetComponent<PushBlock>().type;
        //        if(oppType == playerType || oppType == PlayerType.None) {
        //            on = true;
        //            ChangeSprite(onSprite);
        //            Debug.Log(this.name + " Pressed by " + collision.tag);
        //        }
        //    }
        
        // Else checks if collided with a Player when the Pressure Plate is a Player or Either type
        } else if (plateType == PlateType.Player || plateType == PlateType.Either) {
            // Checks what kind of player
            // This if statement works but isnt great, as it checks for Ghost and Human tags that might be used on moving non player objects in the future
            if ((collision.tag == "Human" && (playerType == PlayerType.Human || playerType == PlayerType.None)) || (collision.tag == "Ghost" && (playerType == PlayerType.Ghost || playerType == PlayerType.None))) {
                lastState = on;
                on = true;

                if (lastState != on) {
                    audioSource.Play();

                }

                ChangeSprite(onSprite);
                Debug.Log(this.name + " Pressed by " + collision.tag);

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        // Checks if the pressure plate has been unpressed by the block
        if ((plateType == PlateType.Block || plateType == PlateType.Either) && collision.tag == "Block") {
            PlayerType otherType = collision.GetComponent<PushBlock>().type;
            if (otherType == playerType || playerType == PlayerType.None) {
                lastState = on;
                on = false;
                ChangeSprite(offSprite);
                Debug.Log("Unpressed by " + collision.tag);

            }

        // Else checks if pressure plate has been unpressed the Player
        } else if (plateType == PlateType.Player || plateType == PlateType.Either) {
            if ((collision.tag == "Human" && (playerType == PlayerType.Human || playerType == PlayerType.None)) || (collision.tag == "Ghost" && (playerType == PlayerType.Ghost || playerType == PlayerType.None))) {
                lastState = on;
                on = false;
                ChangeSprite(offSprite);
                Debug.Log("Unpressed by " + collision.tag);

            }

        }

    }

}
