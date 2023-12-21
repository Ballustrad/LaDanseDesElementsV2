using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocImpact : MonoBehaviour
{
    public int degats = 10; // Dégâts infligés à l'ennemi

    public AudioClip rocDestroyedSound; // Son à jouer
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = SoundManager.instance.audioSource;
    }
    void OnCollisionEnter(Collision collision)
    {

        // Vérifie si l'objet touché a un composant "Ennemi" (à adapter selon votre structure de jeu)
        HealthSystem ennemi = collision.gameObject.GetComponent<HealthSystem>();

        // Si l'objet touché a un composant "Ennemi"
        if (ennemi != null)
         {
      
            ennemi.TakeDamage(degats);
            if (audioSource != null && rocDestroyedSound != null)
            {
                // Joue le son depuis l'AudioSource du soundManager
                audioSource.PlayOneShot(rocDestroyedSound);
            }

            // Détruit le rocher au contact de l'ennemi
            Destroy(gameObject);
        }
        
    }
    void OnDestroy()
    {
        // Vérifie si le son doit être joué avant la destruction de l'objet
        if (audioSource != null && rocDestroyedSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(rocDestroyedSound);
        }
    }
}
