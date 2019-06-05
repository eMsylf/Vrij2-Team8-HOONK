using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float MovementSpeed = 1;
    public float RotationSpeed = 1;

    [SerializeField] private Transform moveGoal;
    [Range(.01f, .9f)]
    [SerializeField] private float movementSpeed2 = .1f;
    [SerializeField] private Transform rotator;
    [SerializeField] private Transform cam;

    private Rigidbody rigidbody_Player;
    private Quaternion rigidbodyQuaternion;
    private Vector3 m_EulerAngleVelocity;

    private float rotation;

    private void Start() {
        rigidbody_Player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Movement2();
        //Rotation();
    }

    private void Movement() {
        if (Input.GetAxis("Vertical") > 0)
        rigidbody_Player.AddForce(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed);
    }

    private void Rotation() {
        rotation = Input.GetAxis("Horizontal") * RotationSpeed;

        //if (Input.GetAxis("Vertical") < 0) {
        //    rotation *= -1;
        //}
        m_EulerAngleVelocity = new Vector3(0, rotation, 0);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rigidbody_Player.MoveRotation(rigidbody_Player.rotation * deltaRotation);
    }

    private void Movement2() {

        Vector3 forwardDirection = Vector3.Scale(cam.forward, new Vector3(1, 0, 1));
        Vector3 rightDirection = cam.right;

        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 velocity = (forwardDirection * vert + rightDirection * hor) * MovementSpeed;
        velocity = Vector3.ClampMagnitude(velocity, MovementSpeed);

        rigidbody_Player.MovePosition(rigidbody_Player.position + velocity * Time.deltaTime);
    }


}
