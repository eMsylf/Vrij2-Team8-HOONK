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
    FMOD.Studio.ParameterInstance PartSelector;
    private void Awake()
    {
        music = RuntimeManager.CreateInstance(Event);
        music.getParameter("PartSelector", out PartSelector);
    }
    private void Start()
    {
        music.start();
    }
}
