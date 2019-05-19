using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fan : MonoBehaviour {
    [SerializeField] private Collider WindHitbox;

    void Awake() {
        FindWindCollider();
    }

    void Update() {
        
    }

    /// <summary>
    /// Find a suitable wind collider that is a trigger among the Fan's children
    /// </summary>
    public void FindWindCollider () {
        for (int i = 0; i < GetComponentsInChildren<Collider>().Length; i++) {
            Collider tempCollider = GetComponentsInChildren<Collider>()[i];
            if (tempCollider.isTrigger) {
                WindHitbox = GetComponentsInChildren<Collider>()[i];
            }
        }

        if (WindHitbox == null) {
            Debug.LogWarning("There's no suitable collider to act as wind in the Fan's children. Make sure there's at least one collider set as Trigger present.");
        }
    }
}
