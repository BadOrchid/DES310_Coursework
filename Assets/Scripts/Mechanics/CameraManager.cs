using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform[] playerPos; // Array to hold references to both players

    public float zoomSpeed = 2.0f;
    public float screenEdgePadding = 2.0f;

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

        //cam size equal to the distance between players
        float camSize = distance;

        // Smoothly adjust the camera size
        playerCam.orthographicSize = Mathf.Lerp(playerCam.orthographicSize, camSize, Time.deltaTime * zoomSpeed);

        // Ensure both players are within the camera's view
        Vector3 direction = (playerPos[1].position - playerPos[0].position).normalized;
        Vector3 cameraOffset = direction * screenEdgePadding;
        Vector3 cameraTargetPosition = centrePoint + cameraOffset;

        // Update the camera's position smoothly
        transform.position = Vector3.Lerp(transform.position, new Vector3(cameraTargetPosition.x, cameraTargetPosition.y, transform.position.z), Time.deltaTime * zoomSpeed);
    }
}
