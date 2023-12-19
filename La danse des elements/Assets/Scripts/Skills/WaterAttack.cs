using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public GameObject bulleEauPrefab; // Référence à l'objet bulle d'eau à instancier
    public int degats = 20; // Dégâts infligés par la bulle d'eau
    public float vitesse = 20f; // Vitesse de déplacement de la bulle d'eau
    public float portee = 10f; // Portée de la bulle d'eau
    public Transform waterStartPoint;
    public AudioClip waterAttackSound;
    public AudioSource audioSource;
    public void PerformWaterAttack()
    {
        // Crée une instance de la bulle d'eau à la position et rotation du personnage
        GameObject bulleEau = Instantiate(bulleEauPrefab, waterStartPoint.position, waterStartPoint.rotation);

        // Ajoute un composant Rigidbody pour permettre le mouvement
        Rigidbody rb = bulleEau.GetComponent<Rigidbody>();
        rb.velocity = waterStartPoint.forward * vitesse;
        if (audioSource != null && waterAttackSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(waterAttackSound);
        }



        // Détruit la bulle d'eau après avoir atteint sa portée
        Destroy(bulleEau, portee);
    }
}
