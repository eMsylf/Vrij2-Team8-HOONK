using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentDetection : MonoBehaviour {

    [Range(.0f, .1f)]
    [SerializeField] private float movementSpeed = .01f;
    [Range(.001f, 1f)]
    [SerializeField] private float turnSpeed = .2f;
    [Range(.0f, 2f)]
    [SerializeField] private float approachDistance = 1f;
    [SerializeField] private Transform movementGoal;
    [SerializeField] private bool huntsPlayer = true;
    [SerializeField] private bool fixatesOnSource = true;
    private bool foundSource = false;
    private Transform scentSource;
    private Transform scentTransform;
    private bool foundPlayer = false;
    private Transform playerTransform;

    private Rigidbody robot_rb;


    private void Start() {
        foundSource = false;
        foundPlayer = false;
        scentTransform = transform;

        movementGoal = Instantiate(movementGoal.gameObject).transform;
        movementGoal.position = transform.position;

        robot_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        // Wat moet er gebeuren als de bron is gevonden?
        // De robot moet de geurbron benaderen tot aan een bepaalde afstand
        // Continuously update the movement goal to follow the scent source's position
        if (foundPlayer) {
            movementGoal.position = playerTransform.position;
        } else if (foundSource) {
            movementGoal.position = scentSource.position;
        }
        // Stop all movements if the source has been approached
        if (Vector3.Distance(transform.position, movementGoal.position) < approachDistance) {
            return;
        }

        // Store current rotation, before LookAt() is executed
        Quaternion currentRotation = transform.rotation;

        // Update desired rotation
        transform.LookAt(movementGoal);
        Quaternion desiredRotation = transform.rotation;

        // Lerp between the current rotation and the desired rotation
        transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, turnSpeed);
        
        LockXZRotations();
        robot_rb.AddForce(transform.forward * movementSpeed, ForceMode.VelocityChange);
        //transform.position += transform.forward * movementSpeed;
    }

    private void OnTriggerEnter(Collider other) {
        if (huntsPlayer) {
            if (foundPlayer) {
                return;
            }
            if (other.GetComponent<PlayerMovement>() != null) {
                foundPlayer = true;
                playerTransform = other.transform;
                movementGoal.position = playerTransform.position;
            }
        }

        if (fixatesOnSource) {
            if (foundSource) {
                return;
            }
            if (other.GetComponent<ScentParticlePool>() != null) {
                // Source has been found
                foundSource = true;
                // Store the transform so the robot can ignore other scent particles
                scentSource = other.transform;

                // Update movement goal position
                movementGoal.position = scentSource.position;

            }
        }

        if (other.GetComponent<Scent>() != null) {
            // Other scent particle has been found
            scentTransform = other.transform;

            // Update movement goal position
            movementGoal.position = scentTransform.position;
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.transform == playerTransform) {
            foundPlayer = false;
            // Move to last remembered spot of where the player was.
            movementGoal.position = other.transform.position;
        } else if (other.transform == scentSource) {
            foundSource = false;
            // Move to last remembered spot of where the scent source was.
            movementGoal.position = scentTransform.position;
        }
    }

    private void LockXZRotations() {
        // Keep x and z rotations at 0
        Quaternion newRotation = transform.rotation;
        transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
    }
}
