using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] ObjectiveType[] leverStates;
    [SerializeField] ObjectiveType[] pressureStates;

    Lever[] levers;
    PressurePlate[] pressurePlates;

    bool complete = true;

    // Start is called before the first frame update
    void Start()
    {
        levers = GetComponentsInChildren<Lever>();
        pressurePlates = GetComponentsInChildren<PressurePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        // Sets complete to true, later to be set false if any object is not in the correct state
        complete = true;

        // Checks if each lever is in the correct state
        int index = 0;
        foreach (Lever lever in levers) {
            switch (leverStates[index]) {
                case ObjectiveType.Off:
                    if (lever.on) {
                        complete = false;

                    }
                    break;
                case ObjectiveType.On:
                    if (!lever.on) {
                        complete = false;

                    }
                    break;
                case ObjectiveType.Either:
                    break;

            }

            if (!complete) {
                break;

            }

            index++;

        }

        // Checks if each pressure plate is in the correct state
        index = 0;
        foreach (PressurePlate plate in pressurePlates) {
            switch (pressureStates[index]) {
                case ObjectiveType.Off:
                    if (plate.on) {
                        complete = false;

                    }
                    break;
                case ObjectiveType.On:
                    if (!plate.on) {
                        complete = false;

                    }
                    break;
                case ObjectiveType.Either:
                    break;

            }

            if (!complete) {
                break;

            }

            index++;

        }

        // Objectives Completed
        if (complete) {
            Debug.Log("COMPLETE");

        }

    }

}
