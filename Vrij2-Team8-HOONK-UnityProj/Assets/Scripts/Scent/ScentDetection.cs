using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentDetection : MonoBehaviour {

    [Range(.01f, .1f)]
    [SerializeField] private float movementSpeed = .01f;

    private Transform destination;

    private void Start() {
        destination = transform;
    }

    private void FixedUpdate() {
        if (transform != destination) {
            Quaternion oldRotation = transform.rotation;

            transform.position = Vector3.MoveTowards(transform.position, destination.position, movementSpeed);
            transform.LookAt(destination);
            // Keep x and z rotations at 0
            Quaternion newRotation = transform.rotation;

            transform.rotation = new Quaternion(0, newRotation.y, 0, newRotation.w);
            
        }


    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Scent particle pool")) {
            destination = other.transform;
            Debug.Log("Updated the destination position");
        }
        else if (other.name.Contains("Scent particle")) {
            destination = other.transform;
            Debug.Log("Updated the destination position");
        }
        else {
            Debug.Log("<b>Nope that's not the right name</b>");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.name.Contains("Scent particle pool")) {
            destination = transform;
            Debug.Log("Updated the destination position to self");
        }
    }

    private void MoveFromTo(Vector3 currentPosition, Vector3 destination) {
        Vector3.Lerp(currentPosition, destination, movementSpeed);
    }
}
