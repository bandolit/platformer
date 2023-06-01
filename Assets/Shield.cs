using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public BossHealth bH;

    [SerializeField] private GameObject batt1;
    [SerializeField] private GameObject batt2;
    [SerializeField] private GameObject batt3;
    [SerializeField] private GameObject batt4;
    // Start is called before the first frame update
    void Start()
    {
        bH.imune = true;
        batt1.SetActive(true);
        batt2.SetActive(true);
        batt3.SetActive(true);
        batt4.SetActive(true);


    }
 

}
