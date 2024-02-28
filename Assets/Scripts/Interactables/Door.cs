using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;

    SpriteRenderer spriteRenderer;

    ObjectivesManager objectivesManager;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectivesManager = GetComponentInParent<ObjectivesManager>();

    }

    // Update is called once per frame
    void Update() {

        // Checks if Objective is complete
        if (objectivesManager.complete) {
            // Do stuff

        }


    }
}
