using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Despawn : MonoBehaviour {
    private Vector3 startingPosition;
    private bool hasDespawned = true;
    private Rigidbody objectRigidbody;


    private void Awake() {
        startingPosition = transform.position;
        objectRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update() {

    }


    public IEnumerator DespawnAfter(float _seconds, GameObject _object) {
        hasDespawned = false;
        Debug.Log("Waiting before despawn...");

        yield return new WaitForSeconds(_seconds);

        Debug.Log(gameObject.name + " despawning.");
        hasDespawned = true;
        DespawnThis(_object);
    }

    /// <summary>
    /// Removes all force-induced motion and deactivates the object.
    /// </summary>
    public void DespawnThis() {
        objectRigidbody.isKinematic = true;
        objectRigidbody.isKinematic = false;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Removes all force-induced motion and deactivates the specified object.
    /// </summary>
    public void DespawnThis(GameObject _object) {
        objectRigidbody.isKinematic = true;
        _object.SetActive(false);
    }
}
