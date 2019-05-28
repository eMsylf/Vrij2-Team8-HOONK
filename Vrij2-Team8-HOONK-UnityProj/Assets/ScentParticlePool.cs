using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentParticlePool : MonoBehaviour {

    [SerializeField] private List<Transform> scentParticlePool;

    [SerializeField] private float intervalSeconds = 1;

    private int iterator = 0;

    private Vector3 spawnPos;

    private void Awake() {
        // Collect all ScentParticles that are presumably the only children of this pool object
        foreach (Transform transform in GetComponentsInChildren<Transform>()) {
            if (transform.gameObject != this.gameObject) {
                scentParticlePool.Add(transform);
                transform.gameObject.SetActive(false);
            }
        }
    }

    void Start() {
        spawnPos = transform.position;
        StartCoroutine(spawnObjectPool());
    }

    private IEnumerator spawnObjectPool() {
        // Spawn an object from the pool at the scent object's position
        scentParticlePool[iterator].gameObject.SetActive(true);
        scentParticlePool[iterator].position = spawnPos;

        iterator++;
        if (iterator >= scentParticlePool.Count) {
            iterator = 0;
        }
        yield return new WaitForSeconds(intervalSeconds);
        StartCoroutine(spawnObjectPool());
    }

}
