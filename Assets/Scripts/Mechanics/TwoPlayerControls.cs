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

    [SerializeField] bool useKeyboard = true;
    [SerializeField] private string horAxisKeyboard;
    [SerializeField] private string verAxisKeyboard;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveHor;
        float moveVer;

        if (useKeyboard) {
            moveHor = Input.GetAxis(horAxisKeyboard);
            moveVer = Input.GetAxis(verAxisKeyboard);

        } else {
            moveHor = Input.GetAxis(horAxisName);
            moveVer = Input.GetAxis(verAxisName);

        }

        Vector2 movement = new Vector2(moveHor, moveVer);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.Normalize();

        playerRB.velocity = movement * moveSpeed;

        // Sets player animation to walking
        animator.SetFloat("speed", playerRB.velocity.magnitude);

        // Sets player to be facing left or right
        if (playerRB.velocity.x != 0) {
            if (playerRB.velocity.x > 0) {
                animator.SetBool("isFacingLeft", false);

            }
            else {
                animator.SetBool("isFacingLeft", true);

            }

        }

        if(Input.GetButtonDown(interactAxisName))
        {
            Debug.Log(this.name + "Interaction Recieved");
        }

    }
}
