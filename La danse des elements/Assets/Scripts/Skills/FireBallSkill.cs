using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkill : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public Transform fireballSpawnPoint;
    public AudioClip fireballSound; // Son � jouer
    public AudioSource audioSource; // R�f�rence � l'AudioSource


    public void UseFireball()
    {
        if (audioSource != null && fireballSound != null)
        {
            // Jouer le son
            audioSource.PlayOneShot(fireballSound);
        }
        // Cr�e une instance de boule de feu � la position et rotation du joueur
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);

        // Obtient la direction dans laquelle la boule de feu doit �tre lanc�e
        Vector3 fireballDirection = fireballSpawnPoint.forward;

        // Applique une force � la boule de feu pour la lancer dans la direction sp�cifi�e avec la vitesse sp�cifi�e
        fireball.GetComponent<Rigidbody>().velocity = fireballDirection.normalized * fireballSpeed;

        // D�truit la boule de feu apr�s un certain temps au cas o� elle ne frappe pas quelque chose
        Destroy(fireball, 5f);
    }
}
