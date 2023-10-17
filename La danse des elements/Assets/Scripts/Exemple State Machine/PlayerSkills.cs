using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public AttackController attackController; // Script de contr�le des attaques

    void Update()
    {
        // G�rer les diff�rentes attaques en fonction de l'�l�ment actuel du joueur
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackController.PerformAttack();
        }
    }
}
