using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Dash>().isDashing == true)
        {
            //EnnemyHealth ennemyHealth = GetComponent<EnnemyHealth>();
            //ennemyHealth.TakeDamage(100);
            GetComponent<BossHealth>().TakeDamage(100);
            Debug.Log("th");
        }
    }
}
