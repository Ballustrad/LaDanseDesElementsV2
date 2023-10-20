using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public GameObject rockPrefab; // R�f�rence � l'objet rocher � lancer
    public float rockSpeed = 10f; // Vitesse de d�placement du rocher
    public int rockDamage = 10; // D�g�ts inflig�s par le rocher
    public Transform startingRockLaunch;
    public void PerformRockAttack()
    {
        // Cr�e une instance du rocher � la position et rotation du personnage
        GameObject rocher = Instantiate(rockPrefab, startingRockLaunch.position, startingRockLaunch.rotation);

        // Obtient la direction dans laquelle le rocher doit �tre lanc�
        Vector3 directionLancer = startingRockLaunch.forward;
        directionLancer.y = 0.2f;

        // Applique une force au rocher pour le lancer dans la direction sp�cifi�e avec la vitesse sp�cifi�e
        rocher.GetComponent<Rigidbody>().velocity = directionLancer.normalized * rockSpeed;

        // Ajoute un composant script � l'objet rocher pour g�rer l'impact et les d�g�ts
        RocImpact rocImpact = rocher.GetComponent<RocImpact>();
        rocImpact.degats = rockDamage;

        // D�truit le rocher apr�s un certain temps au cas o� il ne frappe pas quelque chose
        Destroy(rocher, 5f);
    }
}
