using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SountrackParam : MonoBehaviour
{
    public Music MusicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("music");

    }

    void OnTriggerEnter(Collider collider)
    {
        MusicPlayer.PartSelector = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
