using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayylmao {
    public class RotationCheck : MonoBehaviour {
        public Light correctRotationLight;

        public bool isRotatedCorrectly;
        [Range(0f, 360f)]
        [SerializeField] private float currentRotation;
        [Range(0f, 360f)]
        [SerializeField] private float rotationMin;
        [Range(0f, 360f)]
        [SerializeField] private float rotationMax;


        private int heck = 360;
        private int start;
        private float partitions;

        void Start() {
            if (correctRotationLight == null) {
                if (GetComponentInChildren<Light>() != null) {
                    correctRotationLight = GetComponentInChildren<Light>();
                }
            }
            correctRotationLight.enabled = isRotatedCorrectly;
        }

        void Update() {
            currentRotation = transform.eulerAngles.y;
            if (currentRotation >= rotationMin && currentRotation <= rotationMax) {
                isRotatedCorrectly = true;
            } else {
                isRotatedCorrectly = false;
            }

            correctRotationLight.enabled = isRotatedCorrectly;
        }

        private void OnDrawGizmosSelected() {
            currentRotation = transform.eulerAngles.y;
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);

            Gizmos.color = Color.cyan;

            // Calculate the rotationMin position from the transform.forward and the rotationMin float

            float rotationMinRad = Mathf.Deg2Rad * rotationMin;
            float rotationMaxRad = Mathf.Deg2Rad * rotationMax;

            Vector3 minPos = transform.position + new Vector3(Mathf.Sin(rotationMinRad), 0, Mathf.Cos(rotationMinRad)) * 2f;
            Vector3 maxPos = transform.position + new Vector3(Mathf.Sin(rotationMaxRad), 0, Mathf.Cos(rotationMaxRad)) * 2f;

            //Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            //Gizmos.matrix = rotationMatrix;


            // Calculate points between the two lines

            Gizmos.DrawLine(transform.position, minPos);
            Gizmos.DrawLine(transform.position, maxPos);

            start = Mathf.RoundToInt(rotationMin);
            partitions = heck / rotationMax;

            Gizmos.color = Color.magenta;
            for (int i = start; i < heck; i++) {
                Vector3 tempPos1 = transform.position + new Vector3(Mathf.Sin((rotationMinRad + i - 1) / partitions), 0, Mathf.Cos((rotationMinRad + i - 1) / partitions)) * 2;
                Vector3 tempPos2 = transform.position + new Vector3(Mathf.Sin((rotationMinRad + i) / partitions), 0, Mathf.Cos((rotationMinRad + i) / partitions)) * 2;
                Gizmos.DrawLine(tempPos1, tempPos2);
            }


            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one * 2);


        }

    }
}