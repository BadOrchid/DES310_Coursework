using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    //public Sprite openSprite;
    //public Sprite closeSprite;

    SpriteRenderer spriteRenderer;

    [SerializeField] bool isOpen = false;
    [SerializeField] ObjectivesManager objectivesManager;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Sets whether closed or open door is active
        if (isOpen) {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);

        }
        else {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);

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
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);

        }
        else {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);

        }

    }

}
