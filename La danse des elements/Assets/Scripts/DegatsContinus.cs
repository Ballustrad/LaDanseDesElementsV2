using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatsContinus : MonoBehaviour
{
    public int degatsTotal = 0; // D�g�ts totaux inflig�s

    public float derniereAttaque; // Temps de la derni�re attaque
    public HealthSystem healthSystem;

    public void InfligerDegatsContinus(int degatsParSeconde)
    {
        // Calcule les d�g�ts inflig�s pendant cette attaque
        int degatsInfliges = degatsParSeconde;

        // Ajoute les d�g�ts inflig�s au total des d�g�ts
        degatsTotal += degatsInfliges;

        healthSystem.TakeDamage(degatsInfliges);

        // Met � jour le temps de la derni�re attaque
        derniereAttaque = Time.time;
    }
}
