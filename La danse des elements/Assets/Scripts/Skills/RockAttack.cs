using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{
    public float cooldown;
    public float derniereUtilisation;
    public GameObject rockPrefab; // Référence à l'objet rocher à lancer
    public float rockSpeed = 10f; // Vitesse de déplacement du rocher
    public int rockDamage = 10; // Dégâts infligés par le rocher
    public Transform startingRockLaunch;
    public void PerformRockAttack()
    {
        // Crée une instance du rocher à la position et rotation du personnage
        GameObject rocher = Instantiate(rockPrefab, startingRockLaunch.position, startingRockLaunch.rotation);

        // Obtient la direction dans laquelle le rocher doit être lancé
        Vector3 directionLancer = startingRockLaunch.forward;
        directionLancer.y = 0.2f;

        // Applique une force au rocher pour le lancer dans la direction spécifiée avec la vitesse spécifiée
        rocher.GetComponent<Rigidbody>().velocity = directionLancer.normalized * rockSpeed;

        // Ajoute un composant script à l'objet rocher pour gérer l'impact et les dégâts
        RocImpact rocImpact = rocher.GetComponent<RocImpact>();
        rocImpact.degats = rockDamage;

        // Détruit le rocher après un certain temps au cas où il ne frappe pas quelque chose
        Destroy(rocher, 5f);
    }
}
