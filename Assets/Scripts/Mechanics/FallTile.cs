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
    [SerializeField] Failstates failstate;


    // Start is called before the first frame update
    void Start()
    {
        //tilemap = GetComponent<Tilemap>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = isFilled;

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
                failstate.humanFail = true;

            }
            else if (collision.tag == "Block") {
                Debug.Log("Block fell into place");

                //Debug.Log(collision.bounds);

                isFilled = true;
                Destroy(collision.gameObject);

            }

        }

    }

    //private void OnCollisionEnter2D(Collision2D collision) {
    //    List<ContactPoint2D> contacts = new List<ContactPoint2D>();
    //    collision.GetContacts(contacts);

    //    TileBase tile;

    //    foreach (ContactPoint2D contact in contacts) {
    //        tile = tilemap.GetTile(tilemap.layoutGrid.WorldToCell(contact.point));
    //        Debug.Log(tile.GameObject().transform.position);

    //    }

    //}

}
