using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Music : MonoBehaviour
{
    [EventRef]
    public string Event = "";

    FMOD.Studio.EventInstance music;

    private void Awake()
    {
        music = RuntimeManager.CreateInstance(Event);
    }
    private void Start()
    {
        music.start();
    }
}
