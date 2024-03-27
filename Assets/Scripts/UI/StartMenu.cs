using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject canvasOpt;

    [SerializeField] Button start;
    [SerializeField] Button options;
    [SerializeField] Button quit;
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

}
