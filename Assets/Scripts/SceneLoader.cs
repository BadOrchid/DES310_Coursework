using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReloadScene", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G)) {
            ReloadScene();



        }

    }

    public static void ReloadScene() {
        SceneManager.LoadScene("Level Design Fluffery");

    }

}