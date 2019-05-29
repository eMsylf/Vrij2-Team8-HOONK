using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour {
    [SerializeField] private Transform mainCamera;


    private void Update() {
        gameObject.transform.LookAt(mainCamera);
    }
}
