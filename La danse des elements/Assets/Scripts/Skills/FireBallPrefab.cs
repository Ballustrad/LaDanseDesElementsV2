using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPrefab : MonoBehaviour
{
    public AudioClip WallBreakSound; // Son � jouer
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = SoundManager.instance.audioSource;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet touch� a le tag "Destroyable"
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            if (audioSource != null && WallBreakSound != null)
            {
                // Joue le son depuis l'AudioSource du soundManager
                audioSource.PlayOneShot(WallBreakSound);
            }

            // D�truit l'objet touch�
            Destroy(collision.gameObject);
        }
        
        // D�truit la boule de feu apr�s avoir touch� un objet, que l'objet soit d�truit ou non
        Destroy(gameObject);
    }
}
