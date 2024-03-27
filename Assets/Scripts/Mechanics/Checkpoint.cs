using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Door firstDoor;
    [SerializeField] Door secondDoor;
    [SerializeField] float openAfter = 5.0f;

    TwoPlayerControls[] players;

    // Start is called before the first frame update
    void Start()
    {

        players = PlayerHelper.Find();

    }

    // Update is called once per frame
    void Update()
    {

        if (firstDoor.playersPastDoor)
        {

            Save();

            Invoke("OpenSecondDoor", openAfter);
            
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

        SavedVariables.nextDoor = secondDoor;

    }

    void OpenSecondDoor() {
        secondDoor.isOpen = true;

    }

}
