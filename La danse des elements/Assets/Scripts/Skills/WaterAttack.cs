using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    public int degats = 20; // Dégâts infligés par la bulle d'eau
    public float vitesse = 20f; // Vitesse de déplacement de la bulle d'eau
    public float portee = 10f; // Portée de la bulle d'eau
    public Transform waterStartPoint;

    public void PerformWaterAttack()
    {
        // Crée une instance de la bulle d'eau à la position et rotation du personnage
        GameObject bulleEau = new GameObject("BulleEau");
        bulleEau.transform.position = waterStartPoint.position;
        bulleEau.transform.rotation = waterStartPoint.rotation;

        // Ajoute un composant Rigidbody pour permettre le mouvement
        Rigidbody rb = bulleEau.AddComponent<Rigidbody>();
        rb.velocity = waterStartPoint.forward * vitesse;

        // Ajoute un composant script pour gérer l'impact et les dégâts
        BulleEauImpact bulleEauImpact = bulleEau.AddComponent<BulleEauImpact>();
        bulleEauImpact.degats = degats;

        // Détruit la bulle d'eau après avoir atteint sa portée
        Destroy(bulleEau, portee);
    }
}
