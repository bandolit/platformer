using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update

    //public bool IsDeath()
    //{ 

    //}

        public bool IsAlive()
    {
        if (gameObject.GetComponent<EnnemyHealth>().currentHealth > 0)
        {
            return true;
        }

        else
        {
            Debug.Log("beh");
            return false;
        }
    }

    public void KillEnemy()
    {
        gameObject.GetComponent<EnnemyHealth>().TakeDamage(1000);
    }

}
