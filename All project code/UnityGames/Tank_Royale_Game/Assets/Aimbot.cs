using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Aimbot : MonoBehaviour
{
    public Transform target;
    public Transform FirePoint;
    public GameObject laserPrefab;
    public float fireRate = 0.3F;
    public Vector3 playerPos;
    public Vector3 newPos;
    public Vector3 Vel;
    Vector3 Acc;
    Vector3 vec;


    public float bulletforce = 60F;
    // Start is called before the first frame update
    void Start()
    {
        //Button btn = mouseFire.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        InvokeRepeating("shoot", 2.0f, 0.4f);
        Vel = new Vector3(0, 0, 0);
        Acc = new Vector3(0, 0, 0);
    }
    Vector3 V;
    void shoot()
    {
        GameObject bullet = Instantiate(laserPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletforce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.WorldToViewportPoint(GameObject.Find("PlayerTank").transform.position);

        //angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
