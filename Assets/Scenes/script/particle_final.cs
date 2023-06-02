using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class particle_final : MonoBehaviour
{
    public ParticleSystem finalBoom;
    public BossHealth BH;

    private void Start()
    {
        // Obtient une référence au composant ParticleSystem attaché à cet objet
        finalBoom = GetComponent<ParticleSystem>();
        finalBoom.Stop();
    }

    private void Update()
    {
        // Vérifie si une certaine condition est remplie pour jouer le système de particules
        if (BH.currentHealth<= 0)
        {
            PlayParticleSystem();
        }
    }

    private void PlayParticleSystem()
    {
        // Active et joue le système de particules
        var emission = finalBoom.emission;
        emission.enabled = !emission.enabled;
    }
}