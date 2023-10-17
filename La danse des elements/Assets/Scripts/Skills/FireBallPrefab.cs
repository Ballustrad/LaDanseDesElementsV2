using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPrefab : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet touch� a le tag "Destroyable"
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            

            // D�truit l'objet touch�
            Destroy(collision.gameObject);
        }
        else
        { }
        

        // D�truit la boule de feu apr�s avoir touch� un objet, que l'objet soit d�truit ou non
        Destroy(gameObject);
    }
}
