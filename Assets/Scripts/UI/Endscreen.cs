 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    public GameObject endScreen;

    [SerializeField] ObjectivesManager[] objectiveManagers;

    public bool testBool;
    bool isReady = true;

    public GameObject endOne;
    /*
    public GameObject endTwo;
    public GameObject endThree;
    public GameObject endFour;
    */
    public float sceneSeconds;
    public float startTimer;
    public float lastTimer;
    float baseSceneSeconds;
    float nextScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        baseSceneSeconds = sceneSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
        {
            StartTimer();
        }
        EndScreenEnable();
        if (testBool)
        {
            if (nextScene == 0)
            {
                EndOne();
                Timer();
            }
            /*
            else if (nextScene == 1)
            {
                EndTwo();
                Timer();
            }
            else if (nextScene == 2)
            {
                EndThree();
                Timer();
            }
            else if (nextScene == 3)
            {
                EndFour();
                Timer();
            }
            */
            else
            {
                StartScreen();
            }
        }
        //FinalDoor();
    }

    public void EndScreenEnable()
    {
        testBool = true;
        foreach (ObjectivesManager manager in objectiveManagers) {
            if (!manager.complete) {
                testBool = false;

            }

        }

        if (testBool) {
            endScreen.SetActive(true);

        }

    }

    public void EndOne()
    {
        endOne.SetActive(true);
    }
    /*
    public void EndTwo()
    {
        endTwo.SetActive(true);
        endOne.SetActive(false);
    }

    public void EndThree()
    {
        endThree.SetActive(true);
        endTwo.SetActive(false);
    }

    public void EndFour()
    {
        endFour.SetActive(true);
        endThree.SetActive(false);
    }
    */
    void Timer()
    {
        sceneSeconds -= Time.unscaledDeltaTime;
        if (sceneSeconds <= 0)
        {
            nextScene += 1;
            sceneSeconds = baseSceneSeconds;
        }
    }

    void StartScreen()
    {
        SceneManager.LoadScene("StartScene");
    }

    void StartTimer()
    {
        startTimer -= Time.unscaledDeltaTime;
        if (startTimer <= 0)
        {
            EndTimer();
        }
    }

    void EndTimer()
    {
        if(lastTimer >= 0 && isReady == true)
        {
            lastTimer -= Time.unscaledDeltaTime;
        }
        else if (lastTimer >= 0 && isReady == false)
        {
            isReady = false;
        }
    }
}
