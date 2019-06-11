using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FmodSoundtrack : MonoBehaviour
{   public Button start;
    public string path;







    // Start is called before the first frame update
    void Start()
    {
       
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
