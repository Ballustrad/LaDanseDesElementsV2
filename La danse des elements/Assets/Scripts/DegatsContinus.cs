using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatsContinus : MonoBehaviour
{
    public int degatsTotal = 0; // Dégâts totaux infligés

    public float derniereAttaque; // Temps de la dernière attaque
    public HealthSystem healthSystem;

    public void InfligerDegatsContinus(int degatsParSeconde)
    {
        // Calcule les dégâts infligés pendant cette attaque
        int degatsInfliges = degatsParSeconde;

        // Ajoute les dégâts infligés au total des dégâts
        degatsTotal += degatsInfliges;

        healthSystem.TakeDamage(degatsInfliges);

        // Met à jour le temps de la dernière attaque
        derniereAttaque = Time.time;
    }
}
