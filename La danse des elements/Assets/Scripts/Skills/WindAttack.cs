using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public int degats = 30; // Dégâts infligés par la bourrasque de vent
    public float hauteurZone = 2f; // Hauteur de la zone d'attaque (conique)
    public float largeurZone = 4f; // Largeur de la zone d'attaque (conique)
    public float longueurZone = 10f; // Longueur de la zone d'attaque (conique)
    public Transform windStartPoint;
    public AudioSource audioSource;
    public AudioClip windSwipeSound;
    public GameObject windShownprefab;
    private GameObject windslashInstance;

    IEnumerator WindShow()
    {
        
        
        yield return new WaitForSeconds(1f);
        Destroy(windslashInstance, 5.0f);
    }
    public void PerformWindAttack()
    {
        windslashInstance = Instantiate(windShownprefab, windStartPoint.position, windStartPoint.rotation, windStartPoint);
        // Détermine la direction et l'orientation de la zone d'attaque
        Vector3 direction = windStartPoint.forward;
        Vector3 pointDebut = windStartPoint.position + windStartPoint.up * hauteurZone * 0.5f;
        Vector3 pointFin = pointDebut + direction * longueurZone;
        if (audioSource != null && windSwipeSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(windSwipeSound);
        }
        // Recherche tous les ennemis dans la zone d'attaque
        Collider[] colliders = Physics.OverlapCapsule(pointDebut, pointFin, largeurZone * 0.5f);
        StartCoroutine(WindShow());
        foreach (Collider collider in colliders)
        {
            // Vérifie si l'objet touché a un composant "Ennemi" (à adapter selon votre structure de jeu)
            HealthSystem ennemi = collider.GetComponent<HealthSystem>();

            if (ennemi != null)
            {
                // Inflige des dégâts à l'ennemi
                ennemi.TakeDamage(degats);
            }
        }
    }
}
