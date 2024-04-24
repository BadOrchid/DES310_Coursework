using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndscreenSliding : MonoBehaviour
{
    public RawImage endOne;
    /*
    public RawImage endTwo;
    public RawImage endThree;
    public RawImage endFour;
    */
    public bool stopMoving = false;

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
            if (stopMoving == false)
            {
            endOne.uvRect = new Rect(endOne.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, endOne.uvRect.size);
            }
    }
        if(endOne.uvRect.x >= 0.75)
        {
            stopMoving = true;
        }
    }
}
