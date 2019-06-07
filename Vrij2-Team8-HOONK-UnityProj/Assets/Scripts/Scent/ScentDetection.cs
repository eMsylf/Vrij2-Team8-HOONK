using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentDetection : MonoBehaviour {

    [Range(.01f, .1f)]
    [SerializeField] private float movementSpeed = .01f;


    [SerializeField] private bool foundSource = false;
    private Transform destinationTransform;

    private Transform scentSource;
    private Vector3 destination;

    private void Start() {
        destinationTransform = transform;
        destination = destinationTransform.position;
    }

    private void FixedUpdate() {
        if (foundSource) {
            // Wat moet er gebeuren als de bron is gevonden?
            transform.position = Vector3.MoveTowards(transform.position, scentSource.position, movementSpeed);
            transform.LookAt(scentSource);
            LockXZRotations();
        } else {
            // Store old rotation from the start of the frame
            //Quaternion oldRotation = transform.rotation;

            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed);
            transform.LookAt(destination);

            LockXZRotations();
        }
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("<b>" + name + " is colliding with " + other.name + "</b>");
        if (other.name == ("Source")) {
            destination = other.transform.position;

            scentSource = other.transform;
            Debug.Log("Going to the scent's source");
            foundSource = true;
        } else if (other.name.Contains("Scent particle")) {
            destination = other.transform.position;
            //Debug.Log("Updated the destination position");
        } else {
            //Debug.Log(gameObject.name + " - Non-scent object has entered smell range.");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform == scentSource) {
            destinationTransform = transform;
            Debug.Log("Scent source has left range.");
            Debug.Log("Updated the destination position to self");
            foundSource = false;
        }
    }

    private void MoveFromTo(Vector3 currentPosition, Vector3 destination) {
        Vector3.Lerp(currentPosition, destination, movementSpeed);
    }

    private void LockXZRotations() {
        // Keep x and z rotations at 0
        Quaternion newRotation = transform.rotation;
        transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
    }
}
