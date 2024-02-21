using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerControls : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [SerializeField] public float moveSpeed = 1.5f;

    [SerializeField] private string horAxisName;
    [SerializeField] private string verAxisName;
    [SerializeField] private string interactAxisName;

    [SerializeField] public PlayerType type = PlayerType.None;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHor = Input.GetAxis(horAxisName);
        float moveVer = Input.GetAxis(verAxisName);

        Vector2 movement = new Vector2(moveHor, moveVer);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.Normalize();

        playerRB.velocity = movement * moveSpeed;

        if(Input.GetButton(interactAxisName))
        {
            Debug.Log(this.name + "Interaction Recieved");
        }

    }
}
