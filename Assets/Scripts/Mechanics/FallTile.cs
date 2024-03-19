using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallTile : MonoBehaviour
{

    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("Pitfall collision trigger");

        TwoPlayerControls player = collision.GetComponent<TwoPlayerControls>();

        if (player && collision.tag == "Human") {
            Debug.Log("Human fell from a high place");

        }
        else if (collision.tag == "Block") {
            Debug.Log("Block fell into place");

            Debug.Log(collision.bounds);

            //float top = collision.offset.y + (collision.bounds.size.y / 2.0f);
            //float bottom = collision.offset.y - (collision.bounds.size.y / 2.0f);
            //float left = collision.offset.x - (collision.bounds.size.x / 2.0f);
            //float right = collision.offset.x + (collision.bounds.size.x / 2.0f);

            //Vector2 topLeft = collision.transform.TransformPoint(new Vector2(left, top));
            //Vector2 topRight = collision.transform.TransformPoint(new Vector2(right, top));
            //Vector2 bottomLeft = collision.transform.TransformPoint(new Vector2(left, bottom));
            //Vector2 bottomRight = collision.transform.TransformPoint(new Vector2(right, bottom));

            //TileBase tile;

            //if (tilemap.HasTile(tilemap.layoutGrid.WorldToCell(topLeft))) {
            //    tile = tilemap.GetTile(tilemap.layoutGrid.WorldToCell(topLeft));
            //    Debug.Log("Top Left");

            //} else if (tilemap.HasTile(tilemap.layoutGrid.WorldToCell(topRight))) {
            //    tile = tilemap.GetTile(tilemap.layoutGrid.WorldToCell(topRight));
            //    Debug.Log("Top Right");

            //} else if (tilemap.HasTile(tilemap.layoutGrid.WorldToCell(bottomLeft))) {
            //    tile = tilemap.GetTile(tilemap.layoutGrid.WorldToCell(bottomLeft));
            //    Debug.Log("Bottom Left");

            //} else if (tilemap.HasTile(tilemap.layoutGrid.WorldToCell(bottomRight))) {
            //    tile = tilemap.GetTile(tilemap.layoutGrid.WorldToCell(bottomRight));
            //    Debug.Log("Bottom Right");

            //} else {
            //    Debug.Log("None?");

            //}

        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        collision.GetContacts(contacts);

        TileBase tile;

        foreach (ContactPoint2D contact in contacts) {
            tile = tilemap.GetTile(tilemap.layoutGrid.WorldToCell(contact.point));
            Debug.Log(tile.GameObject().transform.position);

        }

    }

}
