using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar HealthBar;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(50);
        }
        if (currentHealth <= 0)
        {

            Enemy.SetActive(false);

        }


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }

}
