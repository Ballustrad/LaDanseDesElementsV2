using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocImpact : MonoBehaviour
{
    public int degats = 10; // D�g�ts inflig�s � l'ennemi

    public AudioClip rocDestroyedSound; // Son � jouer
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = SoundManager.instance.audioSource;
    }
    void OnCollisionEnter(Collision collision)
    {

        // V�rifie si l'objet touch� a un composant "Ennemi" (� adapter selon votre structure de jeu)
        HealthSystem ennemi = collision.gameObject.GetComponent<HealthSystem>();

        // Si l'objet touch� a un composant "Ennemi"
        if (ennemi != null)
         {
      
            ennemi.TakeDamage(degats);
            if (audioSource != null && rocDestroyedSound != null)
            {
                // Joue le son depuis l'AudioSource du soundManager
                audioSource.PlayOneShot(rocDestroyedSound);
            }

            // D�truit le rocher au contact de l'ennemi
            Destroy(gameObject);
        }
        
    }
    void OnDestroy()
    {
        // V�rifie si le son doit �tre jou� avant la destruction de l'objet
        if (audioSource != null && rocDestroyedSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(rocDestroyedSound);
        }
    }
}
