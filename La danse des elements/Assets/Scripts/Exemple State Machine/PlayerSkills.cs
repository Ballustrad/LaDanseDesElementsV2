using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public GameObject rocherPrefab; // R�f�rence � l'objet rocher � lancer
    public float vitesseRocher = 10f; // Vitesse de d�placement du rocher
    public int degatsImpact = 10; // D�g�ts inflig�s � l'impact
    public float tailleZone = 2f; // Taille de la zone d'impact
    public float delaiEntreAttaques = 1f; // D�lai entre les attaques en secondes
    public float distanceLancer = 5f; // Distance maximale de lancer du rocher

    private float tempsDerniereAttaque; // Temps de la derni�re attaque

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
        // Cr�e une instance du rocher � la position et rotation du personnage
        GameObject rocher = Instantiate(rocherPrefab, transform.position, transform.rotation);

        // Obtient la direction dans laquelle le rocher doit �tre lanc�
        Vector3 directionLancer = transform.forward;
        directionLancer.y = 1f; // Soul�ve l�g�rement le rocher pour un lancer en cloche

        // Applique une force au rocher pour le lancer dans la direction sp�cifi�e avec la vitesse sp�cifi�e
        rocher.GetComponent<Rigidbody>().velocity = directionLancer.normalized * vitesseRocher;

        // Ajoute un composant script � l'objet rocher pour g�rer l'impact et les d�g�ts
        RocImpact rocImpact = rocher.GetComponent<RocImpact>();
        rocImpact.degats = degatsImpact;
        rocImpact.tailleZone = tailleZone;

        // D�truit le rocher apr�s un certain temps au cas o� il ne frappe pas quelque chose
        Destroy(rocher, 5f);
    }
    public void NormalAttackWind()
    {
        print("attaque de vent");
    }
}
