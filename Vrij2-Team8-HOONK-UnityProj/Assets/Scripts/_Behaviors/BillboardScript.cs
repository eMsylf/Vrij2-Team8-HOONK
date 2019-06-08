using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour {
    [SerializeField] private Transform mainCamera;

    private void Start() {
        if (mainCamera == null) {
            mainCamera = Camera.current.transform;
        }
    }

    private void Update() {
        gameObject.transform.LookAt(mainCamera);
    }
}
