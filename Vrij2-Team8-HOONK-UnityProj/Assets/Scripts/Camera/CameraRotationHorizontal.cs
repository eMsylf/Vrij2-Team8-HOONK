using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationHorizontal : MonoBehaviour {
    [SerializeField] private float cameraRotationY;

    [SerializeField] private float rotationSpeed = 1f;
    [Range(.1f, .9f)]
    [SerializeField] private float rotationSmoothing = .9f;

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
    }


}
