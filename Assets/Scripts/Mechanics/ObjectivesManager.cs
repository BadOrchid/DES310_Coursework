using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{

    [SerializeField] float checkRate = 0.5f;
    [SerializeField] bool freezeOnComplete = false;
    [SerializeField] bool freezeLeversOnComplete = false;
    [SerializeField] Door exitDoor;
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
    public bool complete = false;

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
        // Stop checking objectives if both players are past the door
        if (exitDoor != null && exitDoor.playersPastDoor) {
            CancelInvoke();

        }
        else {

            // Sets complete to true, later to be set false if any object is not in the correct state
            bool tempComplete = true;
            int index = 0;

            // Checks if all needed Objectives Managers are complete
            foreach (ObjectivesManager manager in neededObjectivesManagers) {
                if (!manager.complete) {
                    tempComplete = false;
                    break;

                }

            }

            // Skips if needed Objectives Managers are not complete
            if (tempComplete) {

                if (tempComplete) {

                    // Checks if each lever is in the correct state
                    index = 0;
                    foreach (Lever lever in levers) { // Loops over gameobjects
                        switch (leverStates[index]) { // Compares the gameobject's current state to what state it should be in 
                            case ObjectiveType.Off:
                                if (lever.on) {
                                    tempComplete = false;

                                }
                                break;
                            case ObjectiveType.On:
                                if (!lever.on) {
                                    tempComplete = false;

                                }
                                break;
                            case ObjectiveType.Either:
                                break;

                        }

                        // If object is not in correct state, exit loop
                        if (!tempComplete) {
                            break;

                        }

                        index++;

                    }

                }

                if (tempComplete) {

                    // Checks if each pressure plate is in the correct state
                    index = 0;
                    foreach (PressurePlate plate in pressurePlates) { // Loops over gameobjects
                        switch (pressureStates[index]) { // Compares the gameobject's current state to what state it should be in
                            case ObjectiveType.Off:
                                if (plate.on) {
                                    tempComplete = false;

                                }
                                break;
                            case ObjectiveType.On:
                                if (!plate.on) {
                                    tempComplete = false;

                                }
                                break;
                            case ObjectiveType.Either:
                                break;

                        }

                        // If object is not in correct state, exit loop
                        if (!tempComplete) {
                            break;

                        }

                        index++;

                    }

                }

                if (tempComplete) {

                    // Checks if each crystal ball is in the correct state
                    index = 0;
                    foreach (CrystalLight crystal in crystalLights) { // Loops over gameobjects
                        switch (crystalStates[index]) { // Compares the gameobject's current state to what state it should be in 
                            case ObjectiveType.Off:
                                if (crystal.crystalBallHit) {
                                    tempComplete = false;

                                }
                                break;
                            case ObjectiveType.On:
                                if (!crystal.crystalBallHit) {
                                    tempComplete = false;

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

                        }

                    }
                    else {
                        temp = false;
                        pillar.complete = false;

                    }

                    index++;

                }

                // If all pillars are completed, set all pillars to completed
                if (temp) {
                    foreach (RotatingPillar pillar in rotatingPillars) {
                        pillar.complete = true;

                    }

                }
                else {
                    tempComplete = false;

                }


                // Objectives Completed
                complete = tempComplete;

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

}
