using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleEauImpact : MonoBehaviour
{
    public int degats = 20; // D�g�ts inflig�s par la bulle d'eau

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet touch� a un composant "Ennemi" (� adapter selon votre structure de jeu)
        HealthSystem ennemi = other.GetComponent<HealthSystem>();

        if (ennemi != null)
        {
            // Inflige des d�g�ts � l'ennemi
            ennemi.TakeDamage(degats);

            // D�truit la bulle d'eau au contact de l'ennemi
            Destroy(gameObject);
        }
    }
}
