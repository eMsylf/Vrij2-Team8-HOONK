using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {
    public Transform target;
    public Transform CameraTarget;

    [Range(1f, 10f)]
    public float CameraDistance = 3f;
    public float smoothSpeed = .125f;
    //public bool InheritSceneOffset;
    //public Vector3 offset;
    private Vector3 defaultOffset;
    public bool EnableLookAt;

    private Vector3 cameraPosition;
    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    private void Start() {
        //if (InheritSceneOffset) {
        //    offset = transform.position - target.position;
        //} else {
        //    defaultOffset = offset;
        //}
    }

    private void FixedUpdate() {
        //if (Input.GetKeyDown(LookAtToggle)) EnableLookAt = !EnableLookAt;

        // Set Camera Target position
        desiredPosition = target.position;
        smoothedPosition = Vector3.Lerp(CameraTarget.position, desiredPosition, smoothSpeed);
        CameraTarget.position = smoothedPosition;

        // Set Main Camera position (above the target)

        transform.position = CameraTarget.position + CameraTarget.up * CameraDistance;

        // Camera looks at the target
        if (EnableLookAt) transform.LookAt(target);
    }
}
