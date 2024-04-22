 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    public GameObject endScreen;

    public Door finalDoor;
    [SerializeField] ObjectivesManager manager;

    public bool testBool;
    bool brainDead = false;
    bool lolBool = true;

    public GameObject endOne;
    public GameObject endTwo;
    public GameObject endThree;
    public GameObject endFour;

    public float sceneSeconds;
    public float lmaoSeconds;
    public float lolSeconds;
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
        if (lmaoSeconds > 0)
        {
            IfItWorks();
        }
        EndScreenEnable();
        if (testBool)
        {
            if (nextScene == 0)
            {
                EndOne();
                Timer();
            }
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
            else
            {
                StartScreen();
            }
        }
        DoorKun();
    }

    public void EndScreenEnable()
    {
        if (testBool)
        {
            endScreen.SetActive(true);
        }
    }

    public void EndOne()
    {
        endOne.SetActive(true);
    }

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

    void Timer()
    {
        sceneSeconds -= Time.unscaledDeltaTime;
        if (sceneSeconds <= 0)
        {
            nextScene += 1;
            sceneSeconds = baseSceneSeconds;
        }
    }

    void DoorKun()
    {
        if (brainDead == true)
        {
            if (finalDoor.isOpen)
            {
                lolBool = true;
                testBool = true;
            }
        }
    }

    void StartScreen()
    {
        SceneManager.LoadScene("StartScene");
    }

    void IfItWorks()
    {
        lmaoSeconds -= Time.unscaledDeltaTime;
        if (lmaoSeconds <= 0)
        {
            brainDead = true;
            ItWorks();
        }
    }

    void ItWorks()
    {
        if(lolSeconds >= 0 && lolBool == true)
        {
            lolSeconds -= Time.unscaledDeltaTime;
        }
        else if (lolSeconds >= 0 && lolBool == false)
        {
            lolBool = false;
        }
    }
}
