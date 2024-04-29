using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Failstates : MonoBehaviour
{
    public bool humanFail;
    public bool ghostFail;
    private bool failState = false;

    public float panelTimer;
    private float initialPanelTimer;

    [SerializeField] GameObject overlordPanel;
    [SerializeField] GameObject imgHumanFail;
    [SerializeField] GameObject imgGhostFail;

    [SerializeField] Button lastCheckpoint;
    [SerializeField] Button exit;

    private void Awake() {
        Time.timeScale = 1.0f;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HumanFailState();
        GhostFailState();
        Timer();
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
        imgGhostFail.SetActive(false);
        Time.timeScale = 1.0f;

        SceneLoader.ReloadScene();

    }

    public void Timer()
    {
        if (ghostFail == true || humanFail == true)
        {
            failState = true;
        }
        if (failState == true)
        {
            panelTimer -= Time.unscaledDeltaTime;
            if (panelTimer <= 0)
            {
                SceneLoader.ReloadScene();
                panelTimer = initialPanelTimer;
                failState = false;
                ghostFail = false;
                humanFail = false;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
