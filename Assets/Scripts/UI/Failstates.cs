using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Failstates : MonoBehaviour
{
    public bool humanFail;
    public bool ghostFail;

    [SerializeField] GameObject overlordPanel;
    [SerializeField] GameObject imgHumanFail;
    [SerializeField] GameObject imgGhostFail;

    [SerializeField] Button lastCheckpoint;
    [SerializeField] Button exit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HumanFailState();
        GhostFailState();
    }

    public void HumanFailState()
    {
        if (humanFail == true)
        {
            overlordPanel.SetActive(true);
            imgHumanFail.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void GhostFailState()
    {
        if (ghostFail == true)
        {
            overlordPanel.SetActive(true);
            imgGhostFail.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void LastCheckpoint()
    {
        humanFail = false;
        ghostFail = false;
        overlordPanel.SetActive(false);
        imgHumanFail.SetActive(false);
        imgGhostFail.SetActive (false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}
