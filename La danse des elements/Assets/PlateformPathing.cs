using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateformPathing : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] List<Transform> path = new List<Transform>(); // Utilisation de Transform au lieu de GameObject pour stocker le chemin

    

    public void MovePlatformOnPath()
    {
        if (path.Count == 0)
        {
            Debug.LogWarning("Le chemin est vide !");
            return;
        }

        // Convertit les positions des waypoints en Vector3 pour le DOPath
        Vector3[] pathPoints = new Vector3[path.Count];
        for (int i = 0; i < path.Count; i++)
        {
            pathPoints[i] = path[i].position;
        }

        // Spécifie la vitesse de déplacement constante pour le trajet
        float speed = 200f; // Modifier la vitesse selon vos besoins

        // Déplace la plateforme le long du chemin avec une vitesse constante
        platform.DOPath(pathPoints, speed, PathType.Linear, PathMode.Full3D);
    }
}
