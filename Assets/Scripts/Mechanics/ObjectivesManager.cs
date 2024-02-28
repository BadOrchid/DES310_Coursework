using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{

    // Arrays of the state we want each object to be in
    [SerializeField] ObjectiveType[] leverStates;
    [SerializeField] ObjectiveType[] pressureStates;

    // Arrays of the gameobjects
    Lever[] levers;
    PressurePlate[] pressurePlates;

    // True if objective is complete
    public bool complete = true;

    // Start is called before the first frame update
    void Start()
    {
        // Fills array with gameobjects
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
        foreach (Lever lever in levers) { // Loops over gameobjects
            switch (leverStates[index]) { // Compares the gameobject's current state to what state it should be in 
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

            // If object is not in correct state, exit loop
            if (!complete) {
                break;

            }

            index++;

        }

        // Checks if each pressure plate is in the correct state
        index = 0;
        foreach (PressurePlate plate in pressurePlates) { // Loops over gameobjects
            switch (pressureStates[index]) { // Compares the gameobject's current state to what state it should be in
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

            // If object is not in correct state, exit loop
            if (!complete) {
                break;

            }

            index++;

        }

        // Objectives Completed
        if (complete) {
            Debug.Log(this.name + " completed");

        }

    }

}
