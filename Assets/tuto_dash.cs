using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto_dash : MonoBehaviour
{
    public bool isDashing;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Dash>().isDashing== true)
        {
            Destroy(gameObject);
        }
    }
}
