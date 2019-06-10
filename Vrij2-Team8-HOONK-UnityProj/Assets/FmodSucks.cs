using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using FMOD.Studio;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class FmodSucks : MonoBehaviour
{
<<<<<<< Updated upstream
    FMODEventTrack FMOD;
    PARAMETER_ID partselector;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        EventInstance Part = FMODUnity.RuntimeManager.CreateInstance("event/event:/Background Music Ambience/SoundTrack");
        Part.setProperty("PartSelector", 3f);

    }
=======
    public FMODEventMixerBehaviour flop;
    private object Partselector;


    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
            {
                if (collision.gameObject.name == "Player")
                {
            Partselector = 3;
                }
            }
>>>>>>> Stashed changes
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
