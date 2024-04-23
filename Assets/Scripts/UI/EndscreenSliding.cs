using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndscreenSliding : MonoBehaviour
{
    public RawImage endOne;
    public RawImage endTwo;
    public RawImage endThree;
    public RawImage endFour;

    public Endscreen endscreen;

    public float xAxis;
    public float yAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endscreen.testBool)
        {
            endOne.uvRect = new Rect(endOne.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, endOne.uvRect.size);
            endTwo.uvRect = new Rect(endTwo.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, endTwo.uvRect.size);
            endThree.uvRect = new Rect(endThree.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, endThree.uvRect.size);
            endFour.uvRect = new Rect(endFour.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, endFour.uvRect.size);
        }
    }
}
