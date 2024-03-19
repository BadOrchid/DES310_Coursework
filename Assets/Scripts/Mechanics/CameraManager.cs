using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform[] playerPos; // Array to hold references to both players

    public float padding = 1.0f;
    public float zoomSpeed = 2.0f;

    private Camera playerCam;

    void Start()
    {
        playerCam = GetComponent<Camera>();
    }

    void Update()
    {
        //centre point between players
        Vector3 centrePoint = (playerPos[0].position + playerPos[1].position) / 2;

        //distance between players
        float distance = Vector3.Distance(playerPos[0].position, playerPos[1].position);

        // Smoothly adjust the camera size
        playerCam.orthographicSize = Mathf.Lerp(playerCam.orthographicSize, distance, Time.deltaTime * zoomSpeed);

        Vector3 cameraTargetPosition = centrePoint;

        // Update the camera's position smoothly
        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraTargetPosition.x, cameraTargetPosition.y, transform.position.z), Time.deltaTime * zoomSpeed);
    }
}
