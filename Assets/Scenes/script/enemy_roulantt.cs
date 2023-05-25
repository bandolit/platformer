using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_roulantt : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Dash>().isDashing == true)
        {
            //EnnemyHealth ennemyHealth = GetComponent<EnnemyHealth>();
            //ennemyHealth.TakeDamage(100);
            GetComponent<EnnemyHealth>().TakeDamage(50);
            Debug.Log("th");
        }
    }
}
