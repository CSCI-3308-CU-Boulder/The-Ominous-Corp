﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 Vec;
    float speed = 0.05F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vec = transform.localPosition;
        if (Input.GetKey("w"))
        {
            Vec.y += speed;
        }
        if (Input.GetKey("s"))
        {
            Vec.y -= speed;
        }
        if (Input.GetKey("a"))
        {
            Vec.x -= speed;
        }
        if (Input.GetKey("d"))
        {
            Vec.x += speed;
        }
        transform.localPosition = Vec;
    }
}
