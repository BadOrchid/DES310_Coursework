using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerControls : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] public float moveSpeed = 2.0f;

    [SerializeField] private string horAxisName;
    [SerializeField] private string verAxisName;

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
    }
}
