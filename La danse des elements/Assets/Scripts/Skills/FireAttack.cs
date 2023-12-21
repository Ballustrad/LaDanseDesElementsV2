using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public float fireRange = 5f; // Portée du lance-flammes
    public int damage = 10; // Dégâts infligés par seconde
    public float flameWidth = 5f; // Largeur du lance-flammes
    public float flameHeight = 5f; // Hauteur du lance-flammes
    public Transform startingRockLaunch;
    public GameObject fireShown;
    public AudioClip fireSound; // Son à jouer
    public AudioSource audioSource; // Référence à l'AudioSource
    IEnumerator FireShow()
    {
        fireShown.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        fireShown.SetActive(false);
    }
    public void PerformFireAttack()
    {
        if (audioSource != null && fireSound != null)
        {
            // Jouer le son
            audioSource.PlayOneShot(fireSound);
        }
        // Crée un rayon de détection devant le personnage
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red,10);
       // Debug.Break();
        RaycastHit[] hits = Physics.SphereCastAll(ray, flameWidth / 2f, fireRange);
        Debug.DrawRay(ray.origin, ray.direction * fireRange, Color.red);
        StartCoroutine(FireShow()); 
        foreach (RaycastHit hit in hits)
        {
            // Vérifie si l'objet touché a un composant "DegatsContinus" (à adapter selon votre structure de jeu)
           
            HealthSystem target = hit.transform.GetComponent<HealthSystem>();
            if (target != null)
            {
                // Inflige des dégâts à l'objet touché chaque seconde
               target.TakeDamage(damage);
                target.addFireDot();
               
                //Debug.DrawLine(startingRockLaunch.position, hit.point, Color.green, 1f);
            }
        }
    }
}
