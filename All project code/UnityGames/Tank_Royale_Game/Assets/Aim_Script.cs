using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Aim_Script : MonoBehaviour
{
    public Button mouseFire;
    public Transform FirePoint;
    public GameObject laserPrefab;
    public float fireRate = 0.3F;
    private float nextShot = 0.0F;

    public float bulletforce = 60F;
    // Start is called before the first frame update
    void Start()
    {
        //Button btn = mouseFire.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
    }

     void TaskOnClick()
    {
        GameObject bullet = Instantiate(laserPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletforce, ForceMode2D.Impulse);
        bullet.tag = "Projectile";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));

        if (Input.GetMouseButton(0) && (Time.time > nextShot))
        {
            nextShot = Time.time + fireRate;
            TaskOnClick();
        }            
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
