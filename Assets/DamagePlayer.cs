using UnityEngine;


public class DamagePlayer : MonoBehaviour
{
    public GameObject Player;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("ouf");
            collision.gameObject.GetComponent<playerHealth>().TakeDamage(100);
        }
    }
}
