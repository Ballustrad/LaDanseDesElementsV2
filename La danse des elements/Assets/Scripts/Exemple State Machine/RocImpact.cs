using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocImpact : MonoBehaviour
{
    public int degats = 10; // Dégâts infligés à l'ennemi
    public float tailleZone = 2f; // Taille de la zone d'impact

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet touché a un composant "Ennemi" (à adapter selon votre structure de jeu)
        HealthSystem ennemi = collision.gameObject.GetComponent<HealthSystem>();

        // Si l'objet touché a un composant "Ennemi"
        if (ennemi != null)
        {
            // Calcule la distance entre le point d'impact et l'ennemi
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);

            // Si l'ennemi est dans la zone d'impact
            if (distance <= tailleZone)
            {
                // Inflige les dégâts à l'ennemi
                ennemi.TakeDamage(degats);
            }

            // Détruit le rocher au contact de l'ennemi
            Destroy(gameObject);
        }
    }
}
