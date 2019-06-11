using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FanSwitch : MonoBehaviour
{

    public Color lineColor = Color.red;

    public List<Transform> connectedFans;

    public bool onOffSwitch;


    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        // Draws lines between the control block and every connected fan
        for (int i = 0; i < connectedFans.Count; i++)
        {
            if (connectedFans[i] != null)
            {
                Gizmos.DrawLine(transform.position, connectedFans[i].position);
            }
        }
    }

    public void Toggle()
    {
        Debug.Log("Turning " + onOffSwitch);
        onOffSwitch = !onOffSwitch;

        for (int i = 0; i < connectedFans.Count; i++)
        {
            if (connectedFans[i] != null)
            {
                Debug.Log("Applying " + onOffSwitch + " to " + connectedFans[i].name);
                if (onOffSwitch)
                {
                    connectedFans[i].GetComponent<ParticleSystem>().Play();
                }
                else
                {
                    connectedFans[i].GetComponent<ParticleSystem>().Stop(onOffSwitch, ParticleSystemStopBehavior.StopEmitting);
                }
                connectedFans[i].GetComponentInChildren<Wind_Script>().isBlowing = onOffSwitch;
            }
        }
    }
}
