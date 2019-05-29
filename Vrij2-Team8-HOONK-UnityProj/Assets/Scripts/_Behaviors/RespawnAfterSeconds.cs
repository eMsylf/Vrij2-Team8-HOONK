using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RespawnAfterSeconds : MonoBehaviour {
    private Vector3 startingPosition;
    private bool hasJustRespawned = true;
    [SerializeField] private float seconds = 5f;

    private void Awake() {
        startingPosition = transform.position;
    }
    
    void Update() {
        if (hasJustRespawned) {
            StartCoroutine(WaitBeforeRespawn());
        }
    }

    private IEnumerator WaitBeforeRespawn() {
        hasJustRespawned = false;
        Debug.Log("Waiting before respawn...");

        yield return new WaitForSeconds(seconds);

        transform.position = startingPosition;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Debug.Log(gameObject.name + " has respawned.");
        hasJustRespawned = true;
    }
}
