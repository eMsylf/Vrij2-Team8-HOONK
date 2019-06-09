using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    /*
    [Range(.0f, 10f)]
    [SerializeField] private float avoidRadius;
    [Range(.0f, 1f)]
    [SerializeField] private float avoidSpeed;
    [SerializeField] private List<Transform> otherEnemies;
    private Transform otherEnemy;
    private float yPos;
    

    void Start() {
        // Store Y position
        yPos = transform.position.y;
    }
    
    void FixedUpdate() {
        if (otherEnemies.Count > 0) {
            AvoidOtherEnemies();
        }
    }

    private void OnTriggerEnter(Collider other) {
        // Ignore if the transform is the object itself
        if (other.transform == transform) {
            return;
        }
        // Ignore if a transform with the same name is already in the list
        for (int i = 0; i < otherEnemies.Count; i++) {
            if (other.transform.name == otherEnemies[i].name) {
                return;
            }
        }
        if (other.GetComponent<Enemy>() != null) {
            otherEnemy = other.transform;
            otherEnemies.Add(otherEnemy);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Enemy>() != null) {
            otherEnemies.Remove(other.transform);
        }
    }

    private void AvoidOtherEnemies() {
        for (int i = 0; i < otherEnemies.Count; i++) {
            if (Vector3.Distance(transform.position, otherEnemies[i].position) < avoidRadius) {
                Vector3 desiredPosition = Vector3.Lerp(transform.position, (transform.position - otherEnemies[i].position) * avoidRadius, avoidSpeed);

                // Ignore vertical movements
                transform.position = new Vector3(desiredPosition.x, yPos, desiredPosition.z);
            }
        }
    }
    */
}
