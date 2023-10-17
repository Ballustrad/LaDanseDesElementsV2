using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkill : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public Transform fireballSpawnPoint;
        

    public void UseFireball()
    {
        // Crée une instance de boule de feu à la position et rotation du joueur
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);

        // Obtient la direction dans laquelle la boule de feu doit être lancée
        Vector3 fireballDirection = fireballSpawnPoint.forward;

        // Applique une force à la boule de feu pour la lancer dans la direction spécifiée avec la vitesse spécifiée
        fireball.GetComponent<Rigidbody>().velocity = fireballDirection.normalized * fireballSpeed;

        // Détruit la boule de feu après un certain temps au cas où elle ne frappe pas quelque chose
        Destroy(fireball, 5f);
    }
}
