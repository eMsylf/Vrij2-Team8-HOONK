using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {
    [Range(1, 100)]
    public int NumberOfDetectionLines = 3;
    [Range(0, 10)]
    public float ViewDistanceRadius = 5.0f;
    [Range(0, 360)]
    public float ViewAngle = 15.0f;

    private float viewDistanceDiameter;
    private Vector3 drawLineTo;
    private LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.enabled = true;
        //lineRenderer.useWorldSpace = true;
    }

    private void FixedUpdate() {
        ViewConeByRayCast();
    }

    private void ViewConeByRayCast() {
        if (NumberOfDetectionLines == 1) { // 1 detection line
            Formula(0);
            DrawDetectionLinesRaycast(Vector3.zero, drawLineTo);
        } else if (NumberOfDetectionLines % 2 == 0) { // EVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2; i <= NumberOfDetectionLines / 2; i++) {
                Formula(i);
                DrawDetectionLinesRaycast(Vector3.zero, drawLineTo);
            }
        } else { // UNEVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2 - .5f; i <= NumberOfDetectionLines / 2 + .5f; i++) {
                Formula(i);
                DrawDetectionLinesRaycast(Vector3.zero, drawLineTo);
            }
        }
    }
    
    private void OnDrawGizmos() {
        viewDistanceDiameter = ViewDistanceRadius * 2;
        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix;
        


        // Draw view sphere to indicate the range
        Gizmos.DrawWireSphere(Vector3.zero, viewDistanceDiameter);

        if (NumberOfDetectionLines == 1) {
            Formula(0);
            DrawDetectionLinesGizmo(Vector3.zero, drawLineTo);
        } else if (NumberOfDetectionLines % 2 == 0) { // EVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2; i <= NumberOfDetectionLines / 2; i++) {
                Formula(i);
                DrawDetectionLinesGizmo(Vector3.zero, drawLineTo);
            }
        } else { // UNEVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2 - .5f; i <= NumberOfDetectionLines / 2 + .5f; i++) {
                Formula(i);
                DrawDetectionLinesGizmo(Vector3.zero, drawLineTo);
            }
        }
    }

    private void Formula(float detectionLine) {
        // Formula
        float formula = detectionLine * ((ViewAngle * Mathf.Deg2Rad) / NumberOfDetectionLines);

        float xPos = viewDistanceDiameter * Mathf.Sin(formula);
        float yPos = viewDistanceDiameter * Mathf.Cos(formula);

        // Create new line end position using the positions calculated above
        drawLineTo = Vector3.zero + new Vector3(xPos, yPos, 0);
    }

    private void DrawDetectionLinesGizmo(Vector3 startPoint, Vector3 endPoint) {
        Gizmos.DrawLine(startPoint, endPoint);
    }

    private void DrawDetectionLinesRaycast(Vector3 start, Vector3 raycastEnd) {
        Physics.Raycast(start, raycastEnd, out RaycastHit hitInfo, ViewDistanceRadius);
        //Physics.Linecast(transform.position, drawLineTo, out RaycastHit hitInfo);
        HitCheck(hitInfo);

        LineVisualization(start, raycastEnd);
    }

    private void LineVisualization(Vector3 startPoint, Vector3 endpoint) {
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endpoint);
    }

    private void HitCheck(RaycastHit hitInfo) {
        if (hitInfo.transform == null) {
            return;
        } else if (hitInfo.transform.name == "Player") {
            Debug.Log("<b>The " + hitInfo.transform.name + " has been hit!</b>");
        } else {
            Debug.Log("Hit " + hitInfo.transform.name);
        }
    }
}
