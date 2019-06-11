using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnable : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject A;
    public GameObject B;
    public bool onoff;
    void Start()
    {
        onoff = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            onoff = true;
        
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (onoff == true)
            A.SetActive(false);
        B.SetActive(true);
        if (onoff == false)
            A.SetActive(true);
        B.SetActive(false);
    }
}
