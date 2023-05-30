using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public bool imune;

    public HealthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && imune == false)
        {
            Destroy(gameObject);
        }


    }
}
