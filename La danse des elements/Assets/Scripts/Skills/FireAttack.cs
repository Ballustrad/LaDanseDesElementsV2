using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public float fireRange = 5f; // Port�e du lance-flammes
    public int damage = 10; // D�g�ts inflig�s par seconde
    public float flameWidth = 5f; // Largeur du lance-flammes
    public float flameHeight = 5f; // Hauteur du lance-flammes
    public Transform startingRockLaunch;
    public GameObject fireShown;
    public AudioClip fireSound; // Son � jouer
    public AudioSource audioSource; // R�f�rence � l'AudioSource
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
        // Cr�e un rayon de d�tection devant le personnage
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red,10);
       // Debug.Break();
        RaycastHit[] hits = Physics.SphereCastAll(ray, flameWidth / 2f, fireRange);
        Debug.DrawRay(ray.origin, ray.direction * fireRange, Color.red);
        StartCoroutine(FireShow()); 
        foreach (RaycastHit hit in hits)
        {
            // V�rifie si l'objet touch� a un composant "DegatsContinus" (� adapter selon votre structure de jeu)
           
            HealthSystem target = hit.transform.GetComponent<HealthSystem>();
            if (target != null)
            {
                // Inflige des d�g�ts � l'objet touch� chaque seconde
               target.TakeDamage(damage);
                target.addFireDot();
               
                //Debug.DrawLine(startingRockLaunch.position, hit.point, Color.green, 1f);
            }
        }
    }
}
