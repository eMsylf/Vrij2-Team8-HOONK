using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCheck : MonoBehaviour
{
    public Light correctRotationLight;

    public bool isRotatedCorrectly;
    [Range(0f, 360f)]
    [SerializeField] private float currentRotation;
    [Range(0f, 720f)]
    [SerializeField] private float rotationMin;
    [Range(0f, 720f)]
    [SerializeField] private float rotationMax;


    private int heck = 100;
    private float start;
    private float partitions;

    float hur;
    float dur;

    void Start()
    {
        if (correctRotationLight == null)
        {
            if (GetComponentInChildren<Light>() != null)
            {
                correctRotationLight = GetComponentInChildren<Light>();
            }
        }
        correctRotationLight.enabled = isRotatedCorrectly;
    }

    void Update()
    {
        currentRotation = transform.eulerAngles.y;
        if (currentRotation >= rotationMin && currentRotation <= rotationMax)
        {
            isRotatedCorrectly = true;
        }
        else
        {
            isRotatedCorrectly = false;
        }

        correctRotationLight.enabled = isRotatedCorrectly;
    }

    private void OnDrawGizmosSelected()
    {
        currentRotation = transform.eulerAngles.y;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);

        Gizmos.color = Color.cyan;

        // Calculate the rotationMin position from the transform.forward and the rotationMin float

        float rotationMinRad = Mathf.Deg2Rad * rotationMin;
        float rotationMaxRad = Mathf.Deg2Rad * rotationMax;

        Vector3 minPos = transform.position + new Vector3(Mathf.Sin(rotationMinRad), 0, Mathf.Cos(rotationMinRad)) * 2f;
        Vector3 maxPos = transform.position + new Vector3(Mathf.Sin(rotationMaxRad), 0, Mathf.Cos(rotationMaxRad)) * 2f;

        // Calculate points between the two lines

        Gizmos.DrawLine(transform.position, minPos);
        Gizmos.DrawLine(transform.position, maxPos);

        /*
        for (float i = start; i < partitions; i++) {
            Vector3 tempPos1 = transform.position + new Vector3(Mathf.Sin((rotationMinRad + i - 1) / partitions), 0, Mathf.Cos((rotationMinRad + i - 1) / partitions)) * 2;
            Vector3 tempPos2 = transform.position + new Vector3(Mathf.Sin((rotationMinRad + i) / partitions), 0, Mathf.Cos((rotationMinRad + i) / partitions)) * 2;
        }
        */


        partitions = (rotationMaxRad - rotationMinRad);

        for (float i = 0; i < partitions * heck; i++)
        {
            if (i == 0)
            {
                hur = rotationMinRad + i / heck;
            }
            else
            {
                hur = rotationMinRad + (i - 1) / heck;
            }
            dur = rotationMinRad + i / heck;

            Vector3 tempPos1 = transform.position + new Vector3(Mathf.Sin(hur), 0, Mathf.Cos(hur)) * 2;
            Vector3 tempPos2 = transform.position + new Vector3(Mathf.Sin(dur), 0, Mathf.Cos(dur)) * 2;
            Gizmos.DrawLine(tempPos1, tempPos2);
        }

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
}
