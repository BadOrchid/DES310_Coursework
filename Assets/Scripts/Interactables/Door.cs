using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour {
    [SerializeField] public bool playersPastDoor = false;
    [SerializeField] float facingNextRoomAngle = 300;
    [SerializeField] ObjectivesManager[] objectivesManagers;

    [Range(0, 1)][SerializeField] float sfxOpenVolume;
    [Range(0, 1)][SerializeField] float sfxCloseVolume;
    [SerializeField] AudioClip sfxOpen;
    [SerializeField] AudioClip sfxClose;

    SpriteRenderer openRenderer;
    SpriteRenderer closeRenderer;

    EdgeCollider2D doorCollider;
    AudioSource audioSource;

    bool isOpen = false;
    bool lastState;


    bool humanPassed = false;
    bool ghostPased = false;

    Vector2 humanPos1;

    Vector2 ghostPos1;

    void Start() {
        closeRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        openRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();

        doorCollider = GetComponent<EdgeCollider2D>();

        audioSource = GetComponent<AudioSource>();

        // Sets whether closed or open door is active
        if (isOpen) {
            OpenDoor();

        }
        else {
            CloseDoor();

        }

        lastState = isOpen;

    }

    // Update is called once per frame
    void Update() {

        if (objectivesManagers.Length == 0) {
            

        // If players are past door stop checking objectives
        } else if (humanPassed && ghostPased) {
            playersPastDoor = true;
            lastState = isOpen;
            isOpen = false;


        } else {
            playersPastDoor = false;

            // If statements split up for if in future we want to check every x frames and change active door only when isOpen changes

            lastState = isOpen;
            isOpen = true;
            // Checks if all Objectives are complete
            foreach (ObjectivesManager manager in objectivesManagers) {
                if (!manager.complete) {
                    isOpen = false;
                    break;

                }

            }

        }

        if (lastState != isOpen) {
            OpenOrCloseDoor();

        }

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

        audioSource.clip = sfxOpen;
        audioSource.volume = sfxOpenVolume;
        audioSource.Play();

    }

    void CloseDoor() {
        doorCollider.isTrigger = false;

        closeRenderer.enabled = true;
        openRenderer.enabled = false;

        audioSource.clip = sfxClose;
        audioSource.volume = sfxCloseVolume;
        audioSource.Play();

    }

    void OpenOrCloseDoor() {
        if (isOpen) {
            OpenDoor();

        } else {
            CloseDoor();

        }

    }

    public void SetIsOpen(bool isOpen) {
        lastState = isOpen;
        this.isOpen = isOpen;

    }

}
