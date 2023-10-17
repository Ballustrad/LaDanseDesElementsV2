using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public int degats = 30; // D�g�ts inflig�s par la bourrasque de vent
    public float hauteurZone = 2f; // Hauteur de la zone d'attaque (conique)
    public float largeurZone = 4f; // Largeur de la zone d'attaque (conique)
    public float longueurZone = 10f; // Longueur de la zone d'attaque (conique)
    public Transform windStartPoint;
    public void PerformWindAttack()
    {
        // D�termine la direction et l'orientation de la zone d'attaque
        Vector3 direction = windStartPoint.forward;
        Vector3 pointDebut = windStartPoint.position + windStartPoint.up * hauteurZone * 0.5f;
        Vector3 pointFin = pointDebut + direction * longueurZone;

        // Recherche tous les ennemis dans la zone d'attaque
        Collider[] colliders = Physics.OverlapCapsule(pointDebut, pointFin, largeurZone * 0.5f);

        foreach (Collider collider in colliders)
        {
            // V�rifie si l'objet touch� a un composant "Ennemi" (� adapter selon votre structure de jeu)
            HealthSystem ennemi = collider.GetComponent<HealthSystem>();

            if (ennemi != null)
            {
                // Inflige des d�g�ts � l'ennemi
                ennemi.TakeDamage(degats);
            }
        }
    }
}
