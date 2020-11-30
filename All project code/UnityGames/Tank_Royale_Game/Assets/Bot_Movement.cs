using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Bot_Movement : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 newPos;
    public Vector3 Vel;
    Vector3 Acc;
    const float acc = 0.10F;
    const float max_speed = 4F;

    // Start is called before the first frame update
    void Start()
    {
        Vel = new Vector3(0, 0, 0);
        Acc = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("PlayerTank").transform.position;
        newPos = transform.position;
        newPos.x += Vel.x * (1 / 60F);
        newPos.y += Vel.y * (1 / 60F);
        transform.position = newPos;

        if (playerPos.y >= newPos.y + 6 + 4)
        {
            Acc.y = acc;
            if (Vel.y < 0)
            {
                Acc.y *= 1.8F;
            }
        }
        else if (playerPos.y <= newPos.y + 6 - 4)
        {
            Acc.y = -1 * acc;
            if (Vel.y > 0)
            {
                Acc.y *= 1.8F;
            }
        }
        else
        {
            if (Vel.y != 0)
            {
                Acc.y = Mathf.Sign(Vel.y) * acc * -0.5F;
            }
            else
            {
                Acc.y = 0;
            }
        }

        if (playerPos.x <= newPos.x - 11 - 4)
        {
            Acc.x = -1 * acc;
            if (Vel.x > 0)
            {
                Acc.x *= 1.8F;
            }
        }
        else if (playerPos.x >= newPos.x - 11 + 4)
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
