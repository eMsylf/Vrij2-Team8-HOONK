using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour {
    [SerializeField] private float rotationDelay = 1f;
    [SerializeField] private float rotationAmount = 30f;

    void Start() {
        StartCoroutine(Ayylmao());
    }

    private void Update() {
        
    }

    public IEnumerator Ayylmao() {
        yield return new WaitForSeconds(rotationDelay);
        transform.Rotate(0f, rotationAmount, 0f);
        Debug.Log("<b>AAAAAAAAAAAAAAAAAAAAAAAAAA</b>");
        // Repeat
        StartCoroutine(Ayylmao());
    }
}
