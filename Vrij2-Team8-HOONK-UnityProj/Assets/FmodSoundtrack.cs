using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FmodSoundtrack : MonoBehaviour
{   public Button start;
    public string path;
    public int pathselector;
    //private FMOD.Studio.Parameter.Instance instance;
    public Input lol;




    // Start is called before the first frame update
    void Start()
    {
        //lol = FMOD.Studio.System.Instance.GetEvent("event:/Background Music Ambience/SoundTrack");
        pathselector = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        {
            start.onClick.AddListener(delegate { Next(path); }); 
        }
    }
    void Next(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}
