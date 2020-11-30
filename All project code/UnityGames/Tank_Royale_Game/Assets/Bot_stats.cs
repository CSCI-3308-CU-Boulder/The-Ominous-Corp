using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_stats : MonoBehaviour
{
    public int enemyHealth = 100;
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
        if (other.gameObject.tag == "Projectile")
            takeDamage(10);
        
        Debug.Log("Enemy HP: " + enemyHealth);
        if(other.gameObject.tag != "Projectile2")
            Destroy(other.gameObject);
    }

    void takeDamage(int damageVal)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damageVal;
        }
        checkDead();
    }

    void checkDead()
    {
        if(enemyHealth <= 0)
        {
            Debug.Log("win");
        }
    }
}
