﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Target;
    public Vector3 offset;
    void Update()
    {
        if (Target)
        {
            transform.position = Target.transform.position + offset;
        }
        else
        {
            return;
        }
        
    }



}
