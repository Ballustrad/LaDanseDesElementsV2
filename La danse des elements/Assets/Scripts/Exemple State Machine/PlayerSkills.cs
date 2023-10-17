using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public AttackController attackController; // Script de contrôle des attaques

    void Update()
    {
        // Gérer les différentes attaques en fonction de l'élément actuel du joueur
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackController.PerformAttack();
        }
    }
}
