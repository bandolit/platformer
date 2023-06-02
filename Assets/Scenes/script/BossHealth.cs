using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public bool imune;
    public int sceneBuildIndex;

    public HealthBar Hb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Hb.SetMaxHealth(maxHealth);
    }



    public void TakeDamage(int damage)
    {
        if (imune == false)
        {
            currentHealth -= damage;
            Hb.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                Debug.Log("trouduku");
                //Destroy(gameObject);
            }

        }

    }
}
