using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenInWindCollider : MonoBehaviour {

    [SerializeField] private ParticleSystem activateThis;

    private void Awake() {
        if (activateThis == null) {
            if (GetComponent<ParticleSystem>() != null) {
                activateThis = GetComponent<ParticleSystem>();
            }
            else {
                Debug.Log("There's no particle system on this object");
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name + " entered");

        if (collision.gameObject.name == "Wind") {
            activateThis.Play();
        }
    }

    private void OnCollisionExit(Collision collision) {
        Debug.Log(collision.gameObject.name + " left");

        if (collision.gameObject.name == "Wind") {
            activateThis.Pause();
        }
    }
}
