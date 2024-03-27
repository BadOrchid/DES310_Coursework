using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{

    [SerializeField] float checkRate = 0.5f;

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

        InvokeRepeating("CheckObjectives", 2, checkRate);

    }

    // Update is called once per frame
    void Update() {
        
    
    }

    void CheckObjectives() {
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

        // Checks if each rotating pillar is in the correct state
        index = 0;
        foreach (RotatingPillar pillar in rotatingPillars) {
            // Compares the gameobject's current state to what state it should be in
            if (pillar.spritesIndex != rotPillarStates[index]) {
                complete = false;
                break;

            }

            index++;

        }

        // If pillars are in correct state
        bool temp;
        if (index == rotPillarStates.Length) {
            temp = true;

        }
        else {
            temp = false;

        }

        // Tells each pillar that all pillars are in correct state
        foreach (RotatingPillar pillar in rotatingPillars) {
            pillar.complete = temp;

        }

        // Objectives Completed
        if (complete) {
            Debug.Log(this.name + " completed");

        }

    }

}
