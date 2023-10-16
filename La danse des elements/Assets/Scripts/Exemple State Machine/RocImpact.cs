using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocImpact : MonoBehaviour
{
    public int degats = 10; // Dégâts infligés à l'ennemi
    

    void OnCollisionEnter(Collision collision)
    {

        // Vérifie si l'objet touché a un composant "Ennemi" (à adapter selon votre structure de jeu)
        HealthSystem ennemi = collision.gameObject.GetComponent<HealthSystem>();

        // Si l'objet touché a un composant "Ennemi"
        if (ennemi != null)
         {
      
            ennemi.TakeDamage(degats);
        

        // Détruit le rocher au contact de l'ennemi
        Destroy(gameObject);
        }
        
    }
}
