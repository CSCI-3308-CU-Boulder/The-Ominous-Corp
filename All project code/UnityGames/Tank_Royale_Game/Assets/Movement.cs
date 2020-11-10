using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 newPos;
    public Vector3 Vel;
    Vector3 Acc;
    const float acc = 0.05F;
    const float max_speed = 3F;

    // Start is called before the first frame update
    void Start()
    {
        Vel = new Vector3(0, 0, 0);
        Acc = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.localPosition;
        newPos.x += Vel.x * (1 / 60F);
        newPos.y += Vel.y * (1 / 60F);
        transform.localPosition = newPos;

        if (Input.GetKey("w"))
        {
            Acc.y = acc;
            if (Vel.y < 0)
            {
                Acc.y *= 1.8F;
            }
        }
        else if (Input.GetKey("s"))
        {
            Acc.y = -1 * acc;
            if(Vel.y > 0)
            {
                Acc.y *= 1.8F;
            }
        }
        else
        {
            if(Vel.y != 0)
            {
                Acc.y = Mathf.Sign(Vel.y) * acc * -0.5F;
            }
            else
            {
                Acc.y = 0;
            }
        }

        if (Input.GetKey("a"))
        {
            Acc.x = -1 * acc;
            if (Vel.x > 0)
            {
                Acc.x *= 1.8F;
            }
        }
        else if (Input.GetKey("d"))
        {
            Acc.x = acc;
            if (Vel.x < 0)
            {
                Acc.x *= 1.8F;
            }
        }
        else
        {
            if (Vel.x != 0)
            {
                Acc.x = Mathf.Sign(Vel.x) * acc * -0.5F;
            }
            else
            {
                Acc.x = 0;
            }
        }

        Vel.x += Acc.x;
        Vel.y += Acc.y;
        if (Mathf.Abs(Vel.x) >= max_speed)
        {
            Vel.x = Mathf.Sign(Vel.x) * max_speed;
        }
        if (Mathf.Abs(Vel.y) >= max_speed)
        {
            Vel.y = Mathf.Sign(Vel.y) * max_speed;
        }
    }
}
