using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBridgeSkill : MonoBehaviour
{
    public GameObject stoneBridgePrefab;
    public float bridgeLength = 7f;
    public float bridgeDuration = 10f;
    public Transform stoneBridgeSpawnPoint;
    public AudioClip rockBridgeBuildSound; // Son à jouer
    public AudioSource audioSource;
    public void CreateStoneBridge()
    {
        if (audioSource != null && rockBridgeBuildSound != null)
        {
            // Jouer le son
            audioSource.PlayOneShot(rockBridgeBuildSound);
        }
        // Crée un pont de pierre dans la direction du joueur
        Vector3 bridgeDirection = stoneBridgeSpawnPoint.forward;
        Vector3 bridgePosition = stoneBridgeSpawnPoint.position + bridgeDirection * bridgeLength * 0.5f;

        GameObject stoneBridge = Instantiate(stoneBridgePrefab, bridgePosition, Quaternion.LookRotation(bridgeDirection));
        Destroy(stoneBridge, bridgeDuration);
    }
}
