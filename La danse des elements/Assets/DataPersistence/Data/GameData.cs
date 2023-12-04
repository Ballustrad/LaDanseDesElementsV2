using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    /// Player
    public Vector3 playerPosition;

    public int playerMaxHealth;
    public int playerCurrentHealth;


    // Fragments
    public int fireFragments;
    public int waterFragments;
    public int windFragments;
    public int rockFragments;

    // The values defined in this constructor will be the default values
    // the game starts with when there's no data to load

    public GameData()
    {
        // Player
        playerPosition = Vector3.zero;

        playerMaxHealth = 300;
        playerCurrentHealth = playerMaxHealth;

        // Fragments
        this.fireFragments = 0;
        this.waterFragments = 0;
        this.windFragments = 0;
        this.rockFragments = 0;
    }
}
