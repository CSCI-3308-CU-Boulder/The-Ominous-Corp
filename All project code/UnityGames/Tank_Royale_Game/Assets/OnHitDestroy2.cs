﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDestroy2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Projectile2")
            Destroy(other.gameObject);
    }
}