using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rigidbody_Player;
    private Quaternion rigidbodyQuaternion;

    void Start() {
        rigidbody_Player = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (Input.GetAxis("Horizontal") < 0) {
            //move left
            rigidbodyQuaternion = new Quaternion(0, -90, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            //move right
            rigidbodyQuaternion = new Quaternion(0, 90, 0, 0);
        }
        //rigidbodyQuaternion = new Quaternion(0, Input.GetAxis("Horizontal"), 0, 0);
        rigidbody_Player.MoveRotation(rigidbodyQuaternion);
    }
}
