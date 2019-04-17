using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = .125f;
    public bool InheritSceneOffset;
    public Vector3 offset;
    private Vector3 defaultOffset;
    public bool EnableLookAt;
    //public bool ViewTop;

    //private bool cameraIsRotated;
    private float cameraRotation;

    //public KeyCode CameraSwitchKey;
    public KeyCode LookAtToggle;

    private void Start() {
        if (InheritSceneOffset) {
            offset = transform.position - target.position;
        } else {
            defaultOffset = offset;
        }
    }

    private void FixedUpdate() {
        //if (Input.GetKeyDown(CameraSwitchKey)) ViewTop = !ViewTop;

        if (Input.GetKeyDown(LookAtToggle)) EnableLookAt = !EnableLookAt;


        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        /*
        if (ViewTop && EnableLookAt) {
            EnableLookAt = false;
            cameraIsRotated = false;
        }
        if (!ViewTop && !EnableLookAt) {
            EnableLookAt = true;
            cameraIsRotated = !cameraIsRotated;
        }
        */


        if (EnableLookAt) transform.LookAt(target);
        /*
        if (ViewTop) {
            offset.x = 0;
            offset.z = 0;
            cameraRotation = gameObject.transform.rotation.x;
            if (!cameraIsRotated) {
                StartCoroutine(FixCamRotation());
                transform.LookAt(target);
                }
        }
        else {
            offset = defaultOffset;
        }
        */

    }

    /*
    public IEnumerator FixCamRotation() {
        yield return new WaitForSeconds(1.5f);
        cameraIsRotated = true;
    }
    */
}
