using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Script : MonoBehaviour {
    private float windZoneStrength;
    [SerializeField] private float windStrength = 1f;
    [SerializeField] private bool changeWindStrengthFromWindZone = true;

    private float distanceFromFan;

    private void Awake() {
        ApplyWindZoneStrengthToVariables();
    }

    private void FixedUpdate() {
        ApplyWindZoneStrengthToVariables();

        if (changeWindStrengthFromWindZone) {
            windStrength = windZoneStrength;
        }
    }

    private void OnTriggerStay(Collider other) {

        distanceFromFan = Vector3.Distance(gameObject.transform.position, other.transform.position);

        // The wind strength will get weaker, the larger the distance. 1/distance as multiplier?

        float appliedForce = windStrength * (1 / distanceFromFan);

        Debug.Log("Object in wind zone: " + other.name + " || Force applied: " + appliedForce);

        other.attachedRigidbody.AddForce(Vector3.forward * windStrength * (1/distanceFromFan));
    }

    private void ApplyWindZoneStrengthToVariables() {
        windZoneStrength = GetComponentInParent<WindZone>().windMain;
        windStrength = windZoneStrength;
    }
}
