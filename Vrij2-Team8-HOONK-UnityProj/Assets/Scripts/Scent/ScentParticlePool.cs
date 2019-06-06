using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentParticlePool : MonoBehaviour{

    [SerializeField] private GameObject scentParticlePrefab;

    [Range(.01f, 5f)]
    [SerializeField] private float particleIntervalSeconds = 1f;

    [Range(.01f, 10f)]
    [SerializeField] private float startSpeed = 1f;

    [Range(.5f, 10f)]
    [SerializeField] private float setParticleLifetime = 1f;

    [SerializeField] private List<Transform> scentParticlePool;

    private float particleLifetime = 5f;

    private int iterator = 0;

    private Vector3 spawnPos;

    Despawn GetDespawn;

    private void Awake() {
        if (scentParticlePool == null) {
            scentParticlePrefab = gameObject;
        }

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
        StartCoroutine(SpawnObjectPool());
    }

    private void Update() {
        // The particle lifetime cannot be longer than the time it takes to cycle through the list, because the pool will run out of objects to spawn. 
        // So the particle lifetime will always have to be equal to, or shorter than the time it takes to cycle through the list
        if (scentParticlePool.Count/particleIntervalSeconds > setParticleLifetime) {
            particleLifetime = scentParticlePool.Count / particleIntervalSeconds;
        } else {
            particleLifetime = setParticleLifetime;
        }
    }


    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Colliding with " + other.name);
        if (other.name == "Wind") {
            Debug.Log("HECK YEA IT'S REGISTERING");
        } else {
            //Debug.Log("FUCK IT'S NOT REGISTERING");
        }
    }

    private IEnumerator SpawnObjectPool() {
        // Spawn an object from the pool at the scent object's position
        // DEZE MOET ELKE KEER OPNIEUW KIJKEN NAAR SNELHEID EN DE LENGTE VAN DE LIJST, EN JUIST OPVULLEN, 
        // OP HET MOMENT WORDEN SOMMIGE OBJECTEN NIET MEER AANGESPROKEN TERWIJL DAT WEL ZOU MOETEN
        GetDespawn = scentParticlePool[iterator].GetComponent<Despawn>();
        scentParticlePool[iterator].gameObject.SetActive(true);

        StartCoroutine(GetDespawn.DespawnAfter(particleLifetime, scentParticlePool[iterator].gameObject));

        Rigidbody particle_rb = scentParticlePool[iterator].GetComponent<Rigidbody>();

        // Spawn particle slightly above the object
        Vector3 spawnPosTurbulence = new Vector3(Random.Range(-.5f, .5f), .6f);
        UpdateSpawnPos();
        scentParticlePool[iterator].position = spawnPos + spawnPosTurbulence;

        // Reset particle speed ANOTHER TIME because it won't work in the object's script itself
        particle_rb.velocity = Vector3.zero;

        // Give the particle speed
        // THIS SHOULD BE INHERITED FROM THE WIND HITBOX

        particle_rb.AddForce(startSpeed, 0f, 0f, ForceMode.VelocityChange);

        iterator++;
        //Debug.Log(iterator + " / " + scentParticlePool.Count);
        if (iterator >= scentParticlePool.Count) {
            iterator = 0;
        }
        yield return new WaitForSeconds(particleIntervalSeconds);

        // Repeat this coroutine
        StartCoroutine(SpawnObjectPool());
    }

    private void UpdateSpawnPos() {
        spawnPos = transform.position;
    }
}
