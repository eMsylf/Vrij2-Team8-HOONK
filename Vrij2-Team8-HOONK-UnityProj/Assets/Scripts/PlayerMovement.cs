using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float MovementSpeed = 1;
    public float RotationSpeed = 1;

    private Rigidbody rigidbody_Player;
    private Quaternion rigidbodyQuaternion;
    private Vector3 m_EulerAngleVelocity;

    private float rotation;

    private void Start() {
        rigidbody_Player = GetComponent<Rigidbody>();
        

    }

    private void FixedUpdate() {
        Movement();
        Rotation();
    }

    private void Movement() {
        //rigidbody_Player.MovePosition();
        //transform.position += new Vector3 (0, 0, Input.GetAxis("Vertical") * Time.deltaTime);
        rigidbody_Player.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;
    }

    private void Rotation() {
        rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        m_EulerAngleVelocity = new Vector3(0, rotation, 0);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rigidbody_Player.MoveRotation(rigidbody_Player.rotation * deltaRotation);
    }
}
