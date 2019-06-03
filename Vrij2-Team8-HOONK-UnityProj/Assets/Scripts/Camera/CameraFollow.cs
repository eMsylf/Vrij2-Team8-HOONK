﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform MainCamera;
    public Transform CameraMount;
    public Transform MountFollowsThisObject;
    public Transform CameraLooksAtThisObject;

    [Range(1f, 50f)]
    public float CameraDistance = 3f;
    [Range(.1f, 1f)]
    public float smoothSpeed = .125f;
    private Vector3 defaultOffset;

    private Vector3 cameraPosition;
    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;

    //public bool EnableLookAt;

    private void Start()
    {
        if (MainCamera == null && GetComponentInChildren<Camera>() != null)
        {
            Debug.Log("Importing camera from children");
            MainCamera = GetComponentInChildren<Transform>();
        }
        else
        {
            Debug.Log("Camera is already added, or there's no camera among this object's children");
        }
    }

    private void OnValidate()
    {
        SetCameraMountPosition();

        SetMainCameraPosition();

        SetCameraLook();

        MainCamera.GetComponent<Camera>().nearClipPlane = CameraDistance * .25f;
    }

    private void FixedUpdate()
    {
        SetCameraMountPosition();

        SetMainCameraPosition();

        SetCameraLook();
    }

    private void SetCameraMountPosition()
    {
        // Set Camera Mount position
        desiredPosition.x = MountFollowsThisObject.position.x;
        desiredPosition.z = MountFollowsThisObject.position.z;
        desiredPosition.y = CameraMount.position.y;
        smoothedPosition = Vector3.Lerp(CameraMount.position, desiredPosition, smoothSpeed);
        CameraMount.position = smoothedPosition;
    }

    private void SetMainCameraPosition()
    {
        // Set Main Camera position (above the target)
        MainCamera.position = CameraMount.position + CameraMount.up * CameraDistance;
    }

    private void SetCameraLook()
    {
        // Camera looks at the target
        MainCamera.LookAt(CameraLooksAtThisObject);
        //if (EnableLookAt) transform.LookAt(LookTarget);
    }
}
