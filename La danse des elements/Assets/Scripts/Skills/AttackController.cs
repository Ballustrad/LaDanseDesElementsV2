using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public FireAttack fireAttack; // Script de l'attaque de lance-flammes
    public RockAttack rockAttack; // Script de l'attaque de rocher
    public ExamplePlayer examplePlayer;
    public WaterAttack waterAttack;
    private void Start()
    {
        // Initialiser vos références aux scripts d'attaque ici
    }

    public void PerformAttack()
    {
        // Sélectionner l'attaque appropriée en fonction de l'élément actuel du joueur
        switch (examplePlayer.currentElement)
        {
            case 1:
                fireAttack.PerformFireAttack();
                break;
            case 2:
                rockAttack.PerformRockAttack();
                break;

            case 4:
                waterAttack.PerformWaterAttack();
                break;

                // Ajoutez d'autres cas pour les autres types d'attaque
        }
    }
}
