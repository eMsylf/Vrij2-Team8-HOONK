using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationVertical : MonoBehaviour {
    [SerializeField] private float cameraRotationX;

    [SerializeField] private float rotationSpeed = 1f;
    [Range(.1f, .9f)]
    [SerializeField] private float rotationSmoothing = .9f;

    void Start() {
        cameraRotationX = 0f;
    }

    void FixedUpdate() {
        cameraRotationX = Mathf.Lerp(
            cameraRotationX, 
            Input.GetAxis("VerticalR") * rotationSpeed, 
            rotationSmoothing
            );
        transform.Rotate(0f, 0f, cameraRotationX);
    }

    
}
