using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

    
    private Vector3 closedPosition;

    [SerializeField] private float openCloseSpeed;
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private List<RotationCheck> requiredRobots;
    [SerializeField] private Color connectionColor = Color.yellow;
    [SerializeField] private bool doorOpen = false;

    void Start() {
        closedPosition = transform.position;
        openPosition = transform.position + openPosition;
    }

    void FixedUpdate() {
        int rotatedRobots = 0;
        foreach (RotationCheck robot in requiredRobots) {
            if (robot != null) {
                if (robot.isRotatedCorrectly) {
                    rotatedRobots += 1;
                }
            }
        }

        doorOpen = rotatedRobots == requiredRobots.Count;

        if (doorOpen) {
            if (transform.position == openPosition) {
                return;
            } else {
                SlideOpen();
            }
        } else {
            if (transform.position == closedPosition) {
                return;
            } else {
                SlideClosed();
            }
        }
        
    }

    private void SlideOpen() {
        transform.position = Vector3.MoveTowards(transform.position, openPosition, openCloseSpeed);
    }

    private void SlideClosed() {
        transform.position = Vector3.MoveTowards(transform.position, closedPosition, openCloseSpeed);
    }

    private void OnDrawGizmos() {
        Gizmos.color = connectionColor;

        foreach (RotationCheck robot in requiredRobots) {
            if (robot != null) {
                Gizmos.DrawLine(transform.position, robot.transform.position);
            }
        }
    }
}
