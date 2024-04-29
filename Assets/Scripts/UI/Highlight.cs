using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField] Button button;
    public Color selected;
    public Color notSelected;
    private ColorBlock colorBlock;

    // Start is called before the first frame update
    void Start()
    {
        colorBlock = button.colors;
        notSelected = colorBlock.selectedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onEnter()
    {

        colorBlock.selectedColor = selected;
        button.colors = colorBlock;
    }

    public void onExit()
    {
        colorBlock.selectedColor = notSelected;
        button.colors = colorBlock;
    }
}
