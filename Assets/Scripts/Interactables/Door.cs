using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;

    SpriteRenderer spriteRenderer;

    [SerializeField] ObjectivesManager objectivesManager;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {

        // Checks if Objective is complete
        if (objectivesManager.complete) {
            // Do stuff

        }


    }
}
