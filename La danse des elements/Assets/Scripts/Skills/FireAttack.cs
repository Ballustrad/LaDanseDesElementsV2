using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public float fireRange = 5f; // Port�e du lance-flammes
    public int damagePerSecond = 10; // D�g�ts inflig�s par seconde
    public float flameWidth = 5f; // Largeur du lance-flammes
    public float flameHeight = 5f; // Hauteur du lance-flammes
    public Transform startingRockLaunch;

    public void PerformFireAttack()
    {
        // Cr�e un rayon de d�tection devant le personnage
        Ray ray = new Ray(startingRockLaunch.position, startingRockLaunch.forward);
        RaycastHit[] hits = Physics.SphereCastAll(ray, flameWidth / 2f, fireRange);

        foreach (RaycastHit hit in hits)
        {
            // V�rifie si l'objet touch� a un composant "DegatsContinus" (� adapter selon votre structure de jeu)
            DegatsContinus target = hit.transform.GetComponent<DegatsContinus>();

            if (target != null)
            {
                // Inflige des d�g�ts � l'objet touch� chaque seconde
                target.InfligerDegatsContinus(damagePerSecond);
            }
        }
    }
}
