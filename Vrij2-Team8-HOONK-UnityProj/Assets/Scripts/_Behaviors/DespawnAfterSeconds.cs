using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DespawnAfterSeconds : MonoBehaviour {
    private Vector3 startingPosition;
    private bool hasDespawned = true;
    private Rigidbody rigidbody;


    private void Awake() {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update() {
    }

    public IEnumerator WaitBeforeDespawn(GameObject _object, float _seconds) {
        hasDespawned = false;
        Debug.Log("Waiting before despawn...");

        yield return new WaitForSeconds(_seconds);

        Debug.Log(gameObject.name + " despawning.");
        hasDespawned = true;
        Despawn(_object);
    }

    /// <summary>
    /// Removes all force-induced motion and deactivates the object.
    /// </summary>
    public void Despawn() {
        rigidbody.isKinematic = true;
        rigidbody.isKinematic = false;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Removes all force-induced motion and deactivates the specified object.
    /// </summary>
    public void Despawn(GameObject _object) {
        rigidbody.isKinematic = true;
        _object.SetActive(false);
    }
}
