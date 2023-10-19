using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPlate : MonoBehaviour
{
    public Transform destination; // L'endroit o� le joueur sera t�l�port�

    public void TeleportPlayer(Transform playerTransform)
    {
        // T�l�porte le joueur � la destination
        playerTransform.position = destination.position;
    }
}
