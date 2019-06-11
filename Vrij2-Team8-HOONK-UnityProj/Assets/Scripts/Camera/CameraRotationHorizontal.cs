using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationHorizontal : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 1f;
    [Range(.1f, .9f)]
    [SerializeField] private float rotationSmoothing = .9f;
    private float cameraRotationY;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerArt;
    private Quaternion storedRotation;

    [Range(.01f, 1f)]
    [SerializeField] private float playerRotationSmoothing = .33f;

    private PlayerMovement PlayerMovement;
    private ObjectInteraction ObjectInteraction;

    void Start() {
        cameraRotationY = 0f;

        PlayerMovement = player.GetComponent<PlayerMovement>();
        ObjectInteraction = player.GetComponent<ObjectInteraction>();
    }

    void FixedUpdate() {
        cameraRotationY = Mathf.Lerp(
            cameraRotationY, 
            Input.GetAxis("HorizontalR") * rotationSpeed, 
            rotationSmoothing
            );
        transform.Rotate(0f, cameraRotationY, 0f, Space.Self);

        Vector3 forwardDirectionCamera = Vector3.Scale(transform.forward, new Vector3(1, 0, 1));

        if (Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f) {
            playerArt.rotation = storedRotation;
        } else {
            playerArt.rotation = Quaternion.Lerp(
                storedRotation, 
                Quaternion.LookRotation(forwardDirectionCamera * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")), 
                playerRotationSmoothing * PlayerMovement.isHoldingRotationChange);
            StoreLookRotation(playerArt.rotation);
        }
    }

    private void StoreLookRotation(Quaternion quaternion) {
        storedRotation = quaternion;
    }
}
