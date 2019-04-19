using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Eye : MonoBehaviour {
    [Range(1, 100)]
    public int NumberOfDetectionLines = 3;
    [Range(0, 10)]
    public float ViewDistance = 5.0f;
    [Range(0, 360)]
    public float ViewAngle = 15.0f;

    private float viewDiameter;
    private Vector3 drawLineTo;
    private LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        //lineRenderer.useWorldSpace = true;
    }

    private void FixedUpdate() {
        CastRays();
    }

    private void CastRays() {
        if (NumberOfDetectionLines == 1) { // 1 detection line
            DrawDetectionLines(0);
            ForLoopStuff();
        } else if (NumberOfDetectionLines % 2 == 0) { // EVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2; i <= NumberOfDetectionLines / 2; i++) {
                DrawDetectionLines(i);
                ForLoopStuff();
            }
        } else { // UNEVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2 - .5f; i <= NumberOfDetectionLines / 2 + .5f; i++) {
                DrawDetectionLines(i);
                ForLoopStuff();
            }
        }
    }

    private void ForLoopStuff() {
    }

    private void RayVisualisation () {

    }

    private void OnDrawGizmos() {
        viewDiameter = ViewDistance * 2;
        Gizmos.color = Color.red;

        // Draw view sphere to indicate the range
        Gizmos.DrawWireSphere(transform.position, viewDiameter);

        if (NumberOfDetectionLines == 1) {
            DrawDetectionLines(0);
        } else if (NumberOfDetectionLines % 2 == 0) { // EVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2; i <= NumberOfDetectionLines / 2; i++) {
                DrawDetectionLines(i);
                Gizmos.DrawLine(transform.position, drawLineTo);
            }
        } else { // UNEVEN number of detection lines
            for (float i = -NumberOfDetectionLines / 2 - .5f; i <= NumberOfDetectionLines / 2 + .5f; i++) {
                DrawDetectionLines(i);
                Gizmos.DrawLine(transform.position, drawLineTo);
            }
        }
    }

    private void DrawDetectionLines(float i) {
        // Formula
        float formula = i * ((ViewAngle * Mathf.Deg2Rad) / NumberOfDetectionLines);

        float xPos = viewDiameter * Mathf.Cos(formula);
        float yPos = viewDiameter * Mathf.Sin(formula);

        // Create new line end position using the positions calculated above
        drawLineTo = transform.position + new Vector3(xPos, 0, yPos);
        Physics.Linecast(transform.position, drawLineTo, out RaycastHit hitInfo);
        HitCheck(hitInfo);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, drawLineTo);
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

    private void LineVisualization() {

    }
}
