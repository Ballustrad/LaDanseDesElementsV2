using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPrefab : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet touché a le tag "Destroyable"
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            

            // Détruit l'objet touché
            Destroy(collision.gameObject);
        }
        else
        { }
        

        // Détruit la boule de feu après avoir touché un objet, que l'objet soit détruit ou non
        Destroy(gameObject);
    }
}
