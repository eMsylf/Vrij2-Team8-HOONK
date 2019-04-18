using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {
    public float ViewDistance = 5;

    void FixedUpdate() {
        CastRays();
    }

    private void CastRays() {
        Physics.Raycast(transform.position, transform.up, out RaycastHit hitInfo, ViewDistance);
        if (hitInfo.transform == null) {
            return;
        } else if (hitInfo.transform.name == "Player") {
            Debug.Log("<b>The " + hitInfo.transform.name + " has been hit!</b>");
        } else {
            Debug.Log("Hit " + hitInfo.transform.name);
        }
        
    }
}
