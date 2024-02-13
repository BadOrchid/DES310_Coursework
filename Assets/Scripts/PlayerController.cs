using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    private Vector2 moveInput;
    private float playerSpeed = 2.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector2(moveInput.x, moveInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        Debug.Log("Hello");
    }
}
