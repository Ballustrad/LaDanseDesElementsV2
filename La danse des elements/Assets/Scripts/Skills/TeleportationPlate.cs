using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPlate : MonoBehaviour
{
    public Transform destination; // L'endroit où le joueur sera téléporté

    public void TeleportPlayer(Transform playerTransform)
    {
        // Téléporte le joueur à la destination
        playerTransform.position = destination.position;
    }
}
