using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocImpact : MonoBehaviour
{
    public int degats = 10; // D�g�ts inflig�s � l'ennemi
    

    void OnCollisionEnter(Collision collision)
    {

        // V�rifie si l'objet touch� a un composant "Ennemi" (� adapter selon votre structure de jeu)
        HealthSystem ennemi = collision.gameObject.GetComponent<HealthSystem>();

        // Si l'objet touch� a un composant "Ennemi"
        if (ennemi != null)
         {
      
            ennemi.TakeDamage(degats);
        

        // D�truit le rocher au contact de l'ennemi
        Destroy(gameObject);
        }
        
    }
}
