using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReporter : MonoBehaviour {
    [SerializeField] private Vector3 forces;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        forces = rb.velocity;
    }
}
