using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public GameObject bulleEauPrefab; // R�f�rence � l'objet bulle d'eau � instancier
    public int degats = 20; // D�g�ts inflig�s par la bulle d'eau
    public float vitesse = 20f; // Vitesse de d�placement de la bulle d'eau
    public float portee = 10f; // Port�e de la bulle d'eau
    public Transform waterStartPoint;
    public AudioClip waterAttackSound;
    public AudioSource audioSource;
    public void PerformWaterAttack()
    {
        // Cr�e une instance de la bulle d'eau � la position et rotation du personnage
        GameObject bulleEau = Instantiate(bulleEauPrefab, waterStartPoint.position, waterStartPoint.rotation);

        // Ajoute un composant Rigidbody pour permettre le mouvement
        Rigidbody rb = bulleEau.GetComponent<Rigidbody>();
        rb.velocity = waterStartPoint.forward * vitesse;
        if (audioSource != null && waterAttackSound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audioSource.PlayOneShot(waterAttackSound);
        }



        // D�truit la bulle d'eau apr�s avoir atteint sa port�e
        Destroy(bulleEau, portee);
    }
}
