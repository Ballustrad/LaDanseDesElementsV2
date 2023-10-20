using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBridgeSkill : MonoBehaviour
{
    public GameObject stoneBridgePrefab;
    public float bridgeLength = 7f;
    public float bridgeDuration = 10f;
    public Transform stoneBridgeSpawnPoint;

    public void CreateStoneBridge()
    {
        // Crée un pont de pierre dans la direction du joueur
        Vector3 bridgeDirection = stoneBridgeSpawnPoint.forward;
        Vector3 bridgePosition = stoneBridgeSpawnPoint.position + bridgeDirection * bridgeLength * 0.5f;

        GameObject stoneBridge = Instantiate(stoneBridgePrefab, bridgePosition, Quaternion.LookRotation(bridgeDirection));
        Destroy(stoneBridge, bridgeDuration);
    }
}
