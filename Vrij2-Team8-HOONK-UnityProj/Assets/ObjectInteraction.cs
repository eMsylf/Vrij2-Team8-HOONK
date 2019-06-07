using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {

    [SerializeField] private Transform artTransform;
    [Range(0f, 10f)]
    [SerializeField] private float maxInteractionRange = 2f;
    [Range(1f, 3f)]
    [SerializeField] private float pickupHoldDistance = 2f;
    [SerializeField] private float rotationAmount = 30f;

    // Face buttons
    KeyCode a = KeyCode.Joystick1Button0;
    KeyCode b = KeyCode.Joystick1Button1;
    KeyCode x = KeyCode.Joystick1Button2;
    KeyCode y = KeyCode.Joystick1Button3;

    // Bumper buttons
    KeyCode lb = KeyCode.Joystick1Button4;
    KeyCode rb = KeyCode.Joystick1Button5;

    private Ray ray;
    private RaycastHit hitInfo;

    [SerializeField] private Transform pickup;
    [SerializeField] private Rigidbody pickup_rb;

    void Start() {

    }

    void FixedUpdate() {
        Physics.Raycast(new Ray(artTransform.position, artTransform.forward), out hitInfo, maxInteractionRange);

        if (pickup != null) {
            if (Input.GetKeyDown(a)) {
                DropObject();
            }

            if (Input.GetKeyDown(lb)) {
                pickup.transform.Rotate(0, -rotationAmount, 0);
                Debug.Log("L1, turn object LEFT");

            }
            if (Input.GetKeyDown(rb)) {
                pickup.transform.Rotate(0, rotationAmount, 0);
                Debug.Log("R1, turn object RIGHT");
            }
        }
        else if (pickup == null) {
            if (hitInfo.transform != null) {
                if (hitInfo.transform.GetComponent<PickupObject>() != null) {
                    if (Input.GetKeyDown(a)) {
                        PickupObject();
                    }
                }
            }
        }
    }

    private void PickupObject() {
        Debug.Log("Pickup " + hitInfo.transform.name);
        // Store variables
        pickup = hitInfo.transform;
        pickup_rb = pickup.GetComponent<Rigidbody>();

        // Move position to 
        pickup.transform.position = artTransform.position + artTransform.forward * pickupHoldDistance;
        pickup.GetComponent<Rigidbody>().isKinematic = true;

        pickup.SetParent(artTransform);
    }

    private void DropObject() {
        Debug.Log("Drop " + hitInfo.transform.name);
        pickup.GetComponent<Rigidbody>().isKinematic = false;
        pickup.SetParent(null);
        pickup = null;
    }
}
