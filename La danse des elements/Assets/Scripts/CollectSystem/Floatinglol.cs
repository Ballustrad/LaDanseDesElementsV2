using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatinglol : MonoBehaviour
{
    public float rotationSpeed = 20.0f; // Vitesse de rotation de l'objet
    public float floatStrength = 0.5f; // Intensité du mouvement de haut en bas
    public float floatSpeed = 1.0f; // Vitesse du mouvement de haut en bas

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Rotation de l'objet sur lui-même
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Mouvement de haut en bas
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = newPosition;
    }
}
