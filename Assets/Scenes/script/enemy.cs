using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemy : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3 (-0.4068991f, 0.4068991f, 0.4068991f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3 (0.4068991f, 0.4068991f, 0.4068991f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Dash>().isDashing==true)  
        {
            //EnnemyHealth ennemyHealth = GetComponent<EnnemyHealth>();
            //ennemyHealth.TakeDamage(100);
            GetComponent<EnnemyHealth>().TakeDamage(50);
            Debug.Log("th");
        }
    }
}
