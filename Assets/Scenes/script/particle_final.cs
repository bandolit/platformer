using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class particle_final : MonoBehaviour
{
    public ParticleSystem finalBoom;
    public BossHealth BH;

    private void Start()
    {
        // Obtient une r�f�rence au composant ParticleSystem attach� � cet objet
        finalBoom = GetComponent<ParticleSystem>();
        finalBoom.Stop();
    }

    private void Update()
    {
        // V�rifie si une certaine condition est remplie pour jouer le syst�me de particules
        if (BH.currentHealth<= 0)
        {
            PlayParticleSystem();
        }
    }

    private void PlayParticleSystem()
    {
        // Active et joue le syst�me de particules
        var emission = finalBoom.emission;
        emission.enabled = !emission.enabled;
    }
}