using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Music : MonoBehaviour
{
    [EventRef]
    public string Event = "";

    FMOD.Studio.EventInstance music;
    public float PartSelector;

    public void Awake()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("music");
        if (objects.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        music = RuntimeManager.CreateInstance(Event);
        music.getParameterByName("PartSelector", out PartSelector);
        PartSelector = 1;
    }

    private void Start()
    {
        music.start();
    }
    
    
}
