using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentParticlePool : MonoBehaviour{

    [SerializeField] private GameObject scentParticlePrefab;

    [Range(.01f, 5f)]
    [SerializeField] private float particleIntervalSeconds = 1f;

    [Range(.01f, 10f)]
    [SerializeField] private float startSpeed = 1f;

    [SerializeField] private List<Transform> scentParticlePool;

    private float particleLifetime = 5f;

    private int iterator = 0;

    private Vector3 spawnPos;

    DespawnAfterSeconds GetDespawnAfterSeconds;

    private void Awake() {
        // Collect all ScentParticles in the pool, and exclude the pool object itself.
        foreach (Transform scentTransform in GetComponentsInChildren<Transform>()) {
            if (scentTransform != transform) {
                scentParticlePool.Add(scentTransform);
                scentTransform.gameObject.SetActive(false);
            }
        }
        int scentParticlesAvailable = GetComponentsInChildren<Transform>().Length;
        int scentParticlePoolCapacity = scentParticlePool.Count;

        Debug.Log("Scent particles available: " + scentParticlesAvailable + ". Scent particle pool capacity: " + scentParticlePoolCapacity);

        if (scentParticlesAvailable < scentParticlePoolCapacity) {
            int spotsRemaining = scentParticlePoolCapacity - scentParticlesAvailable;
            Debug.Log("There are " + spotsRemaining + " spots remaining.");
            Debug.Log("Filling up remaining spaces with scent particles.");
            if (scentParticlePrefab == null) {
                Debug.LogWarning("The scent particle prefab is not assigned. Please do so in the '" + gameObject.name + "'.");
            } else {
                for (int i = 0; i <= spotsRemaining; i++) {
                    Transform currentSpawnTransform = Instantiate(scentParticlePrefab).transform;
                    
                    Debug.Log("Adding " + currentSpawnTransform.name + "to pool position " + i);
                    scentParticlePool[i] = currentSpawnTransform;

                    currentSpawnTransform.gameObject.SetActive(false);
                }
                Debug.Log("Done filling. There are now " + scentParticlePool.Count + " scent particles in the pool.");
            }
        }
    }

    void Start() {
        spawnPos = transform.position;
        StartCoroutine(spawnObjectPool());
    }

    private void Update() {
        particleLifetime = scentParticlePool.Count / particleIntervalSeconds;
    }

    private IEnumerator spawnObjectPool() {
        // Spawn an object from the pool at the scent object's position
        // DEZE MOET ELKE KEER OPNIEUW KIJKEN NAAR SNELHEID EN DE LENGTE VAN DE LIJST, EN JUIST OPVULLEN, 
        // OP HET MOMENT WORDEN SOMMIGE OBJECTEN NIET MEER AANGESPROKEN TERWIJL DAT WEL ZOU MOETEN
        scentParticlePool[iterator].gameObject.SetActive(true);
        GetDespawnAfterSeconds = scentParticlePool[iterator].GetComponent<DespawnAfterSeconds>();

        StartCoroutine(GetDespawnAfterSeconds.WaitBeforeDespawn(scentParticlePool[iterator].gameObject, particleLifetime));



        Vector3 spawnPosTurbulence = new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        UpdateSpawnPos();
        scentParticlePool[iterator].position = spawnPos + spawnPosTurbulence;


        // Give the particle speed
        // THIS SHOULD BE INHERITED FROM THE WIND HITBOX
        Rigidbody particle_rb = scentParticlePool[iterator].GetComponent<Rigidbody>();

        particle_rb.isKinematic = false;
        particle_rb.AddForce(startSpeed, 0f, 0f, ForceMode.VelocityChange);

        iterator++;
        Debug.Log(iterator + " / " + scentParticlePool.Count);
        if (iterator >= scentParticlePool.Count - 1) {
            iterator = 0;
        }
        yield return new WaitForSeconds(particleIntervalSeconds);

        StartCoroutine(spawnObjectPool());
    }

    private void UpdateSpawnPos() {
        spawnPos = transform.position;
    }
}
