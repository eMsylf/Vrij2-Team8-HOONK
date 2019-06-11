using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;


public class FmodSoundtrack : MonoBehaviour
{   
    
    [EventRef]
    public string Event = "";

    FMOD.Studio.EventInstance music;
    float PartSelector;
    public void Awake()
    {
        music = RuntimeManager.CreateInstance(Event);
        music.getParameterByName("PartSelector", out PartSelector);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PartSelector = 3;
        }
    }

    private void Start()
    {
        music.start();
    }
}
