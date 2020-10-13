using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour
{
    Vector3 V;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        V = GameObject.Find("PlayerTank").GetComponent<Movement>().Vel;
        float rotAng = angle(new Vector2(V.x, V.y));
        transform.localEulerAngles = new Vector3(0, 0, rotAng);
    }

    private float angle(Vector2 vec)
    {
        float sign = (vec.y < 0) ? -1f : 1f;
        return Vector2.Angle(Vector2.right, vec) * sign - 90;
    }
}
