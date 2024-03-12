using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    [SerializeField] Button start;
    [SerializeField] Button load;
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
        SceneManager.LoadScene("Main Scene");
    }
    public void LoadGame()
    {

    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
