using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public float fireRange = 5f; // Portée du lance-flammes
    public int damagePerSecond = 10; // Dégâts infligés par seconde
    public float flameWidth = 5f; // Largeur du lance-flammes
    public float flameHeight = 5f; // Hauteur du lance-flammes
    public Transform startingRockLaunch;

    public void PerformFireAttack()
    {
        // Crée un rayon de détection devant le personnage
        Ray ray = new Ray(startingRockLaunch.position, startingRockLaunch.forward);
        RaycastHit[] hits = Physics.SphereCastAll(ray, flameWidth / 2f, fireRange);

        foreach (RaycastHit hit in hits)
        {
            // Vérifie si l'objet touché a un composant "DegatsContinus" (à adapter selon votre structure de jeu)
            DegatsContinus target = hit.transform.GetComponent<DegatsContinus>();

            if (target != null)
            {
                // Inflige des dégâts à l'objet touché chaque seconde
                target.InfligerDegatsContinus(damagePerSecond);
            }
        }
    }
}
