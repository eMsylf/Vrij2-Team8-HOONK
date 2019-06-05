using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationHorizontal : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 1f;
    [Range(.1f, .9f)]
    [SerializeField] private float rotationSmoothing = .9f;
    private float cameraRotationY;
    [SerializeField]
    private Transform player;

    void Start() {
        cameraRotationY = 0f;
    }

    void FixedUpdate() {
        cameraRotationY = Mathf.Lerp(
            cameraRotationY, 
            Input.GetAxis("HorizontalR") * rotationSpeed, 
            rotationSmoothing
            );
        transform.Rotate(0f, cameraRotationY, 0f, Space.Self);

        Vector3 forwardDirectionCamera = Vector3.Scale(transform.forward, new Vector3(1, 0, 1));
        player.rotation = Quaternion.LookRotation( forwardDirectionCamera * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal") );
    }
}
