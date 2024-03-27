using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    //public Sprite openSprite;
    //public Sprite closeSprite;

    SpriteRenderer spriteRenderer;

    [SerializeField] bool isOpen = false;
    [SerializeField] ObjectivesManager objectivesManager;

    SpriteRenderer openRenderer;
    SpriteRenderer closeRenderer;

    Collider2D openCollider;
    Collider2D closeCollider;

    void Start() {
        //spriteRenderer = GetComponent<SpriteRenderer>();

        closeRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        openRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();

        closeCollider = transform.GetChild(0).GetComponent<Collider2D>();
        //openCollider = transform.GetChild(1).GetComponent<Collider2D>();


        // Sets whether closed or open door is active
        if (isOpen) {
            OpenDoor();

        }
        else {
            CloseDoor();

        }

    }

    // Update is called once per frame
    void Update() {

        // If statements split up for if in future we want to check every x frames and change active door only when isOpen changes

        // Checks if Objective is complete
        if (objectivesManager.complete) {
            isOpen = true;

        }
        else {
            isOpen = false;

        }

        // Sets whether closed or open door is active
        if (isOpen) {
            OpenDoor();

        }
        else {
            CloseDoor();

        }

    }

    void OpenDoor() {
        closeRenderer.enabled = false;
        closeCollider.enabled = false;

        openRenderer.enabled = true;
        //openCollider.enabled = true;

    }

    void CloseDoor() {
        closeRenderer.enabled = true;
        closeCollider.enabled = true;

        openRenderer.enabled = false;
        //openCollider.enabled = false;

    }

}
