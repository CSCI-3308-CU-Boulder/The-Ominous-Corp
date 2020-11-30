using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    public int health = 100;
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
        if (other.gameObject.tag == "Projectile2")
        {
            takeDamage(10);
            Destroy(other.gameObject);
        }
        Debug.Log(health);
    }

    void takeDamage(int damageVal)
    {
        if (health > 0)
        {
           health -= damageVal;
        }
        checkDead();
    }

    void checkDead()
    {
        if (health <= 0)
        {
            Debug.Log("Lose");
        }
    }
}
