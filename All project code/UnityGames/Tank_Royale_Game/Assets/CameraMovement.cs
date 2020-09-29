using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 myPos;
    public Transform myPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myPlay = GameObject.Find("PlayerTank").transform;
        transform.position = myPlay.position + new Vector3(0,0,-10);
    }
}
