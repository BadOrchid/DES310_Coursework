using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Door firstDoor;
    [SerializeField] Door secondDoor;
    [SerializeField] float openAfter = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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


    }

    void OpenSecondDoor() {
        secondDoor.isOpen = true;

    }

}
