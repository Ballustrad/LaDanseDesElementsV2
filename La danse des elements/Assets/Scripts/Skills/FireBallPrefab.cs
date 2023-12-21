using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPrefab : MonoBehaviour
{
    public AudioClip WallBreakSound; // Son à jouer
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = SoundManager.instance.audioSource;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet touché a le tag "Destroyable"
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            if (audioSource != null && WallBreakSound != null)
            {
                // Joue le son depuis l'AudioSource du soundManager
                audioSource.PlayOneShot(WallBreakSound);
            }

            // Détruit l'objet touché
            Destroy(collision.gameObject);
        }
        
        // Détruit la boule de feu après avoir touché un objet, que l'objet soit détruit ou non
        Destroy(gameObject);
    }
}
