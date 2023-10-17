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
    public WindAttack windAttack;
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
                if (Time.time - fireAttack.derniereUtilisation >= fireAttack.cooldown)
                {
                    fireAttack.PerformFireAttack();
                    fireAttack.derniereUtilisation = Time.time;
                }
                break;
            case 2:
                if (Time.time - rockAttack.derniereUtilisation >= rockAttack.cooldown)
                {
                    rockAttack.PerformRockAttack();
                    rockAttack.derniereUtilisation = Time.time;
                }
                break;
            case 3:
                if (Time.time - windAttack.derniereUtilisation >= windAttack.cooldown)
                {
                    windAttack.PerformWindAttack();
                    windAttack.derniereUtilisation = Time.time;
                }
                break;
            case 4:
                if (Time.time - waterAttack.derniereUtilisation >= waterAttack.cooldown)
                {
                    waterAttack.PerformWaterAttack();
                    waterAttack.derniereUtilisation = Time.time;
                }
                break;
            default:
                break;

                // Ajoutez d'autres cas pour les autres types d'attaque
        }
    }
}
