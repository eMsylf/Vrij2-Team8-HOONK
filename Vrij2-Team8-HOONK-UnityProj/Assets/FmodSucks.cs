using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class FmodSucks : MonoBehaviour
{
    FMODEventTrack FMOD;
    PARAMETER_ID partselector;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        EventInstance Part = FMODUnity.RuntimeManager.CreateInstance("event/event:/Background Music Ambience/SoundTrack");
        Part.setProperty("PartSelector", 3f);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
