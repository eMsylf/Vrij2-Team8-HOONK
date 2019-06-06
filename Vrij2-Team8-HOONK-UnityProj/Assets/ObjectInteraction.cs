using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {

    [SerializeField] private Transform artTransform;
    [Range(0f, 10f)]
    [SerializeField] private float maxInteractionRange = 2f;
    [Range(1f, 3f)]
    [SerializeField] private float pickupHoldDistance = 2f;

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

    private Transform pickup;

    void Start() {

    }

    void FixedUpdate() {
        Physics.Raycast(new Ray(artTransform.position, artTransform.forward), out hitInfo, maxInteractionRange);

        if (pickup != null) {
            if (Input.GetKeyDown(a)) {
                DropObject();
            }

            if (Input.GetKey(KeyCode.Joystick1Button4)) {
                Debug.Log("L1, turn object LEFT");

            }
            if (Input.GetKey(KeyCode.Joystick1Button5)) {
                Debug.Log("R1, turn object RIGHT");
            }
        }
        else if (pickup == null) {
            if (Input.GetKeyDown(a)) {
                if (hitInfo.transform != null) {
                    if (hitInfo.transform.GetComponent<PickupObject>() != null) {
                        if (Input.GetKeyDown(a)) {
                            PickupObject();
                        }
                    }
                }
            }
        }
    }

    private void PickupObject() {
        Debug.Log("Pickup " + hitInfo.transform.name);
        pickup = hitInfo.transform;
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
