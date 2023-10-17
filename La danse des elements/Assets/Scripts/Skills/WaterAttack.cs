using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    public int degats = 20; // D�g�ts inflig�s par la bulle d'eau
    public float vitesse = 20f; // Vitesse de d�placement de la bulle d'eau
    public float portee = 10f; // Port�e de la bulle d'eau
    public Transform waterStartPoint;

    public void PerformWaterAttack()
    {
        // Cr�e une instance de la bulle d'eau � la position et rotation du personnage
        GameObject bulleEau = new GameObject("BulleEau");
        bulleEau.transform.position = waterStartPoint.position;
        bulleEau.transform.rotation = waterStartPoint.rotation;

        // Ajoute un composant Rigidbody pour permettre le mouvement
        Rigidbody rb = bulleEau.AddComponent<Rigidbody>();
        rb.velocity = waterStartPoint.forward * vitesse;

        // Ajoute un composant script pour g�rer l'impact et les d�g�ts
        BulleEauImpact bulleEauImpact = bulleEau.AddComponent<BulleEauImpact>();
        bulleEauImpact.degats = degats;

        // D�truit la bulle d'eau apr�s avoir atteint sa port�e
        Destroy(bulleEau, portee);
    }
}
