using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform[] playerPos; // Array to hold references to both players

    public float padding = 1.0f;
    public float zoomSpeed = 2.0f;
    public float minOrthographicSize = 2.0f; // Minimum camera size
    public float maxOrthographicSize = 10.0f; // Maximum camera size

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
        float targetOrthographicSize = Mathf.Lerp(playerCam.orthographicSize, distance, Time.deltaTime * zoomSpeed);
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);
        playerCam.orthographicSize = targetOrthographicSize;

        Vector3 cameraTargetPosition = centrePoint;

        // Update the camera's position smoothly
        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraTargetPosition.x, cameraTargetPosition.y, transform.position.z), Time.deltaTime * zoomSpeed);
    }
}