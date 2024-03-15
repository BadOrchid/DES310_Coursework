using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    [SerializeField] bool playerInRange = false;

    int[] angles = { 0, 60, 90, 120, 180, 240, 270, 300 };
    int angleIndex = 0;

    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInRange) {
            UserInput();

        }

        rotation = Quaternion.Euler(0, 0, angles[angleIndex]);

        transform.rotation = rotation;

    }

    void UserInput() {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O)) {
            angleIndex++;

            if (angleIndex == angles.Length) {
                angleIndex = 0;

            }

        }

    }

}
