using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public GameObject rocherPrefab; // Référence à l'objet rocher à lancer
    public float vitesseRocher = 10f; // Vitesse de déplacement du rocher
    public int degatsImpact = 10; // Dégâts infligés à l'impact
    public float tailleZone = 2f; // Taille de la zone d'impact
    public float delaiEntreAttaques = 1f; // Délai entre les attaques en secondes
    public float distanceLancer = 5f; // Distance maximale de lancer du rocher

    private float tempsDerniereAttaque; // Temps de la dernière attaque

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            switch (examplePlayer.currentElement) 
            {
                case 1:
                    NormalAttackFire();
                    break;
                case 2:
                    NormalAttackEarth();
                    break;
                case 3:
                    NormalAttackWind();
                    break;
                case 4:
                    NormalAttackWater();
                    break;
            }
        }
    }
    public void NormalAttackFire()
    {
        print("attaque de feu");
    }
    public void NormalAttackWater()
    {
        print("attaque d'eau");
    }
    public void NormalAttackEarth()
    {
        print("attaque de terre");
        // Crée une instance du rocher à la position et rotation du personnage
        GameObject rocher = Instantiate(rocherPrefab, transform.position, transform.rotation);

        // Obtient la direction dans laquelle le rocher doit être lancé
        Vector3 directionLancer = transform.forward;
        directionLancer.y = 1f; // Soulève légèrement le rocher pour un lancer en cloche

        // Applique une force au rocher pour le lancer dans la direction spécifiée avec la vitesse spécifiée
        rocher.GetComponent<Rigidbody>().velocity = directionLancer.normalized * vitesseRocher;

        // Ajoute un composant script à l'objet rocher pour gérer l'impact et les dégâts
        RocImpact rocImpact = rocher.GetComponent<RocImpact>();
        rocImpact.degats = degatsImpact;
        rocImpact.tailleZone = tailleZone;

        // Détruit le rocher après un certain temps au cas où il ne frappe pas quelque chose
        Destroy(rocher, 5f);
    }
    public void NormalAttackWind()
    {
        print("attaque de vent");
    }
}
