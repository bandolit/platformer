using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar HealthBar;
    public GameObject Batt;

    public Protection prot;

    public BossBattle BB;
    public bool BattDeactivated = false;


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

            prot.NbrBatCas++;
            gameObject.SetActive(false);
            //Debug.Log("Nombre de batterie désactivé pour l'instant est de: " + BB.somme);
            //BB.BattNumber();
            //BattDeactivated = true;
            //Debug.Log("waw, I don't sert à quelque chose");

        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Dash>().isDashing == true)
        {
            //EnnemyHealth ennemyHealth = GetComponent<EnnemyHealth>();
            //ennemyHealth.TakeDamage(100);
            GetComponent<BattHealth>().TakeDamage(50);
            Debug.Log("th");
        }
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }


}
