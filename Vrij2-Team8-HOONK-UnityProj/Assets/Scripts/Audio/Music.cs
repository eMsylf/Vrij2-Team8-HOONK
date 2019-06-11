using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Music : MonoBehaviour
{
    [EventRef]
    public string Event = "";
    internal int PartSelector;
    FMOD.Studio.EventInstance music;
    
   public void Awake()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("music");
        if (objects.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        music = RuntimeManager.CreateInstance(Event);
        float PartSelector;
        music.getParameterByName("PartSelector", out PartSelector);
        
    }

    private void Start()
    {
        music.setParameterByName("PartSelector", 0.5f);
        music.start();
    }
    
    
}
