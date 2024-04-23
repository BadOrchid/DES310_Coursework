using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallTile : MonoBehaviour
{

    //Tilemap tilemap;

    public bool isFilled = false;
    SpriteRenderer spriteRenderer;

    Failstates failState;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = isFilled;

        failState = FindAnyObjectByType<Failstates>();

    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = isFilled;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("Pitfall collision trigger");

        if (!isFilled) {

            TwoPlayerControls player = collision.GetComponent<TwoPlayerControls>();

            if (player && collision.tag == "Human") {
                Debug.Log("Human fell from a high place");
                failState.humanFail = true;

            }
            else if (collision.tag == "Block") {
                Debug.Log("Block fell into place");

                //Debug.Log(collision.bounds);

                isFilled = true;
                Destroy(collision.gameObject);

            }

        }

    }

}
