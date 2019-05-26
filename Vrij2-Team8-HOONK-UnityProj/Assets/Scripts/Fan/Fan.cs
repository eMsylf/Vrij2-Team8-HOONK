using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    [SerializeField] private WindZone windZone;
    [SerializeField] private Collider WindHitbox;
    [Range(0f, 100f)]
    [SerializeField] private float currentStrength;
    [Range(0f, 100f)]
    [SerializeField] private float fanStrengthMin = 1f;
    [Range(0f, 100f)]
    [SerializeField] private float fanStrengthMax = 10f;
    [Range(.01f, 1f)]
    [SerializeField] private float strengthChangeSpeed = .1f;

    private float strengthMultiplier;

    void Awake() {
        if (GetComponent<WindZone>() == null) {
            gameObject.AddComponent<WindZone>();
        } else {
            windZone = GetComponent<WindZone>();
        }
        FindWindTrigger();
    }

    void FixedUpdate() {
        currentStrength = Mathf.Sin(Time.time * strengthChangeSpeed) * (Mathf.Abs(fanStrengthMax - fanStrengthMin) / 2) + Mathf.Abs((fanStrengthMax + fanStrengthMin) / 2);
        //Debug.Log(currentStrength);

    }

    /// <summary>
    /// Find a suitable wind collider that is a trigger among the Fan's children. This is done, assuming that there is only one trigger among the children
    /// </summary>
    public void FindWindTrigger() {
        for (int i = 0; i < GetComponentsInChildren<Collider>().Length; i++) {
            Collider tempCollider = GetComponentsInChildren<Collider>()[i];
            if (tempCollider.isTrigger) {
                if (tempCollider.name.Contains("Wind")) {
                    WindHitbox = GetComponentsInChildren<Collider>()[i];
                }
            }
        }

        if (WindHitbox == null) {
            Debug.LogWarning("There's no suitable collider to act as wind in the Fan's children. Make sure there's at least one collider set as Trigger present, that has 'Wind' in its name");
        }
    }
}
