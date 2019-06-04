using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {

    [Range(0f, 10f)]
    [SerializeField] private float maxInteractionRange = 2f;
    [Range(1f, 3f)]
    [SerializeField] private float pickupHoldDistance = 2f;

    KeyCode x = KeyCode.Joystick1Button2;
    KeyCode lb = KeyCode.Joystick1Button4;
    KeyCode rb = KeyCode.Joystick1Button5;
    private Ray ray;
    private RaycastHit hitInfo;

    private Transform pickup;

    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        Physics.Raycast(new Ray(transform.position, transform.forward), out hitInfo, maxInteractionRange);


        // Release
        if (pickup != null) {
            pickup.transform.position = transform.position + transform.forward * pickupHoldDistance;

            if (Input.GetKeyUp(x)) {
                pickup.GetComponent<Rigidbody>().isKinematic = false;
                pickup.SetParent(null);
                pickup = null;
            }
        }

        // Pickup
        if (hitInfo.transform != null) {
            if (hitInfo.transform.GetComponent<PickupObject>() != null && Input.GetKeyDown(x)) {
                Debug.Log("Pickup " + hitInfo);
                pickup = hitInfo.transform;
                pickup.GetComponent<Rigidbody>().isKinematic = true;

                pickup.SetParent(transform);
            }
        }
        


        if (Input.GetKey(KeyCode.Joystick1Button4)) {
            Debug.Log("L1");
        }
        if (Input.GetKey(KeyCode.Joystick1Button5)) {
            Debug.Log("R1");
        }
    }
}
