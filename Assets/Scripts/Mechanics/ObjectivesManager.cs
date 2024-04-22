using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{

    [SerializeField] float checkRate = 0.5f;
    [SerializeField] bool freezeOnComplete = false;
    [SerializeField] bool freezeLeversOnComplete = false;
    [SerializeField] ObjectivesManager[] neededObjectivesManagers;

    // Arrays of the state we want each object to be in
    [SerializeField] ObjectiveType[] leverStates;
    [SerializeField] ObjectiveType[] pressureStates;
    [SerializeField] ObjectiveType[] crystalStates;
    [SerializeField] int[] rotPillarStates;

    // Arrays of the gameobjects
    Lever[] levers;
    PressurePlate[] pressurePlates;
    CrystalLight[] crystalLights;
    RotatingPillar[] rotatingPillars;

    // True if objective is complete
    public bool complete = true;

    // Start is called before the first frame update
    void Start()
    {
        // Fills array with gameobjects
        levers = GetComponentsInChildren<Lever>();
        pressurePlates = GetComponentsInChildren<PressurePlate>();
        crystalLights = GetComponentsInChildren<CrystalLight>();
        rotatingPillars = GetComponentsInChildren<RotatingPillar>();

        InvokeRepeating("CheckObjectives", 1, checkRate);

    }

    // Update is called once per frame
    void Update() {
        
    
    }

    void CheckObjectives() {
        // Sets complete to true, later to be set false if any object is not in the correct state
        complete = true;
        int index = 0;

        // Checks if all needed Objectives Managers are complete
        foreach (ObjectivesManager manager in neededObjectivesManagers) {
            if (!manager.complete) {
                complete = false;
                break;

            }

        }

        // Skips if needed Objectives Managers are not complete
        if (complete) {

            if (complete) {

                // Checks if each lever is in the correct state
                index = 0;
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

            }

            if (complete) {

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

            }

            if (complete) {

                // Checks if each crystal ball is in the correct state
                index = 0;
                foreach (CrystalLight crystal in crystalLights) { // Loops over gameobjects
                    switch (crystalStates[index]) { // Compares the gameobject's current state to what state it should be in 
                        case ObjectiveType.Off:
                            if (crystal.crystalBallHit) {
                                complete = false;

                            }
                            break;
                        case ObjectiveType.On:
                            if (!crystal.crystalBallHit) {
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

            }

            // Checks if each rotating pillar is in the correct state
            index = 0;
            bool temp = true;
            foreach (RotatingPillar pillar in rotatingPillars) {
                // Compares the gameobject's current state to what state it should be in
                if (pillar.spritesIndex == rotPillarStates[index]) {
                    if (!pillar.waitForAllComplete) {
                        pillar.complete = true;
                        Debug.Log(index + " Complete?");

                    }

                } else {
                    temp = false;
                    pillar.complete = false;
                    
                    Debug.Log(index + " Not Complete");

                }

                index++;

            }

            // If all pillars are completed, set all pillars to completed
            if (temp) {
                foreach (RotatingPillar pillar in rotatingPillars) {
                    pillar.complete = true;

                }

            } else {
                complete = false;

            }


            // Objectives Completed
            if (complete) {
                if (freezeLeversOnComplete) {
                    foreach (Lever lever in levers) {
                        lever.freeze = true;

                    }

                }

                Debug.Log(this.name + " completed");

                // Stops checking objectives once completed and is set to toggle
                if (freezeOnComplete) {
                    CancelInvoke("CheckObjectives");

                }

            }

        }

    }

}
