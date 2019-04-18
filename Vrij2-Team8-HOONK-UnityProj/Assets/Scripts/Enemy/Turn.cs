using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {
    public float RotationSpeed = 1;
    private float rotation;

    private void Start() {
        rotation = transform.rotation.y;
    }

    private void FixedUpdate() {
        transform.Rotate(0, RotationSpeed, 0);
    }
}
