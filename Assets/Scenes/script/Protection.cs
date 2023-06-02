using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour
{
    public int NbrBatCas;
    public BossHealth bh;
    [SerializeField] GameObject shield1;
    [SerializeField] GameObject shield2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NbrBatCas == 4)
        {
            shield1.SetActive(false);
            shield2.SetActive(false);
            bh.imune = false;
            NbrBatCas = 0;
        }
    }
}
