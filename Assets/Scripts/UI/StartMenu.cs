using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject canvasOpt;

    [SerializeField] Button start;
    [SerializeField] Button options;
    [SerializeField] Button quit;
    [SerializeField] Button optQuit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SavedVariables.humanPos = SavedVariables.humanStartPos;
        SavedVariables.ghostPos = SavedVariables.ghostStartPos;
        SavedVariables.checkpointNum = 0;
        SceneManager.LoadScene("Level Design Fluffery");
    }

    public void Options()
    {
        canvasOpt.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptQuit()
    {
        canvasOpt.SetActive(false);
    }
}
