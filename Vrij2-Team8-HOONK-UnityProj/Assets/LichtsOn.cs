﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichtsOn : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    private void OnColliderEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetTrigger("CompRoom");
        }
    }
}