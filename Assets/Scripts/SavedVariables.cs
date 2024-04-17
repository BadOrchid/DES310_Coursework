using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{

    public static Vector2 humanPos;
    public static Vector2 ghostPos;
    public static int checkpointNum;

    static bool firstLoad = true;

    private void Awake() {
        if (firstLoad) {
            firstLoad = false;

        }
        else {

            TwoPlayerControls[] players = PlayerHelper.Find();

            if (PlayerHelper.CheckType(PlayerType.Human, players[0])) {
                players[0].transform.position = humanPos;
                players[1].transform.position = ghostPos;

            }
            else {
                players[1].transform.position = humanPos;
                players[0].transform.position = ghostPos;

            }

            Checkpoint[] checkpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);

            foreach (Checkpoint checkpoint in checkpoints) {

                if (checkpoint.checkpointNum == checkpointNum) {
                    checkpoint.secondDoor.SetIsOpen(true);

                }

            }

        }

    }

}
