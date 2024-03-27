using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour {
    //public Sprite openSprite;
    //public Sprite closeSprite;

    SpriteRenderer spriteRenderer;

    [SerializeField] bool isOpen = false;
    [SerializeField] bool playersPastDoor = false;
    [SerializeField] float facingNextRoomAngle = 300;
    [SerializeField] ObjectivesManager objectivesManager;

    SpriteRenderer openRenderer;
    SpriteRenderer closeRenderer;

    EdgeCollider2D doorCollider;

    bool humanPassed = false;
    bool ghostPased = false;

    Vector2 humanPos1;

    Vector2 ghostPos1;

    void Start() {
        closeRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        openRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();

        doorCollider = GetComponent<EdgeCollider2D>();


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

        // If players are past door stop checking objectives
        if (humanPassed && ghostPased) {
            playersPastDoor = true;
            isOpen = false;


        } else {
            playersPastDoor = false;

            // If statements split up for if in future we want to check every x frames and change active door only when isOpen changes

            // Checks if Objective is complete
            if (objectivesManager.complete) {
                isOpen = true;

            }
            else {
                isOpen = false;

            }

        }

        OpenOrCloseDoor();

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.GetComponent<TwoPlayerControls>()) {
            if (collision.tag == "Human") {
                humanPos1 = collision.transform.position;

            } else if (collision.tag == "Ghost") {
                ghostPos1 = collision.transform.position;

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<TwoPlayerControls>()) {
            if (collision.tag == "Human") {
                float angle = CalcAngle(humanPos1, collision.transform.position);
                Debug.Log(angle);
                if (angle < 90 && angle > -90) {
                    humanPassed = true;

                } else {
                    humanPassed = false;

                }
                
            }
            else if (collision.tag == "Ghost") {
                float angle = CalcAngle(ghostPos1, collision.transform.position);

                if (angle < 90 && angle > -90) {
                    ghostPased = true;

                }
                else {
                    ghostPased = false;

                }

            }

        }

    }

    float CalcAngle(Vector2 start, Vector2 end) {
        Vector2 direction = end - start;
        direction.Normalize();
        return Vector2.SignedAngle(Quaternion.Euler(0, 0, facingNextRoomAngle) * Vector2.up, direction);

    }

    void OpenDoor() {
        doorCollider.isTrigger = true;

        closeRenderer.enabled = false;
        openRenderer.enabled = true;

    }

    void CloseDoor() {
        doorCollider.isTrigger = false;

        closeRenderer.enabled = true;
        openRenderer.enabled = false;      

    }

    void OpenOrCloseDoor() {
        if (isOpen) {
            OpenDoor();

        } else {
            CloseDoor();

        }

    }

}
