using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodSoundtrack : MonoBehaviour
{

    void Next(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
