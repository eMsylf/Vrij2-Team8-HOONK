using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Script : MonoBehaviour {
    public bool isBlowing = false;

    private float windZoneStrength;
    [SerializeField] private float windStrength = 1f;

    private float distanceFromFan;


    private void OnTriggerStay(Collider other) {
        if (!isBlowing) {
            return;
        }
        if (other.attachedRigidbody == null) {
            return;
        }
        distanceFromFan = Vector3.Distance(gameObject.transform.position, other.transform.position);

        // The wind strength will get weaker, the larger the distance. 1/distance as multiplier?

        float appliedForce = windStrength * (1 / distanceFromFan);

        //Debug.Log("Object in wind zone: " + other.name + " || Force applied: " + appliedForce);

        
        other.attachedRigidbody.AddForce(transform.up * windStrength * (1/distanceFromFan));
    }
}
