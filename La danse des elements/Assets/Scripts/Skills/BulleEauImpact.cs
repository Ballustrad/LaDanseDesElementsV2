using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleEauImpact : MonoBehaviour
{
    public int degats = 20; // Dégâts infligés par la bulle d'eau

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet touché a un composant "Ennemi" (à adapter selon votre structure de jeu)
        HealthSystem ennemi = other.GetComponent<HealthSystem>();

        if (ennemi != null)
        {
            // Inflige des dégâts à l'ennemi
            ennemi.TakeDamage(degats);

            // Détruit la bulle d'eau au contact de l'ennemi
            Destroy(gameObject);
        }
    }
}
