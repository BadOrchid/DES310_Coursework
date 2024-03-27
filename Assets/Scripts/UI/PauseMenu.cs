using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasOpt;
    bool timeZero = false;

    [SerializeField] Button resume;
    [SerializeField] Button options;
    [SerializeField] Button quit;
    [SerializeField] Button quitOpt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Menu();
        if (Time.timeScale != 1.0f)
        {
            timeZero = true;
        }
    }

    public void Menu()
    {
        if (Input.GetButtonDown(buttonName: "Tab") && timeZero == false)
        {
            canvas.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (Input.GetButtonDown(buttonName: "Tab") && timeZero == true)
        {
            Resume();
        }
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
        timeZero = false;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        canvasOpt.SetActive(true);
    }

    public void OptionsQuit()
    {
        canvasOpt.SetActive(false);
    }
}
