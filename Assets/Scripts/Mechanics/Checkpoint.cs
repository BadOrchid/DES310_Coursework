using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] public int checkpointNum;
    [SerializeField] Door firstDoor;
    [SerializeField] public Door secondDoor;
    [SerializeField] float openAfter = 5.0f;

    TwoPlayerControls[] players;

    // Start is called before the first frame update
    void Start()
    {

        players = PlayerHelper.Find();

        if (checkpointNum == 0) {
            if (PlayerHelper.CheckType(PlayerType.Human, players[0])) {
                SavedVariables.humanPos = players[0].transform.position;
                SavedVariables.ghostPos = players[1].transform.position;

            }
            else {
                SavedVariables.humanPos = players[1].transform.position;
                SavedVariables.ghostPos = players[0].transform.position;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointNum != 0) {
            if (firstDoor.playersPastDoor && SavedVariables.checkpointNum != checkpointNum) {
                Save();

                Invoke("OpenSecondDoor", openAfter);

            }

        }

    }

    void Save() {
        if (PlayerHelper.CheckType(PlayerType.Human, players[0])) {
            SavedVariables.humanPos = players[0].transform.position;
            SavedVariables.ghostPos = players[1].transform.position;

        } else {
            SavedVariables.humanPos = players[1].transform.position;
            SavedVariables.ghostPos = players[0].transform.position;

        }

        SavedVariables.checkpointNum = checkpointNum;

    }

    void OpenSecondDoor() {
        secondDoor.SetIsOpen(true);

    }

}
