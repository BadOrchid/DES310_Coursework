 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    public GameObject endscreen;

    public bool testBool;

    public GameObject endOne;
    public GameObject endTwo;
    public GameObject endThree;
    public GameObject endFour;

    public float sceneSeconds;
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
    }

    public void EndScreenEnable()
    {
        if (testBool)
        {
            endscreen.SetActive(true);
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

    void StartScreen()
    {
        SceneManager.LoadScene("StartScene");
    }
}
