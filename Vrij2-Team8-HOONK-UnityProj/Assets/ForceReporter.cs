using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReporter : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 forces;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        forces = rb.velocity;
    }
}
