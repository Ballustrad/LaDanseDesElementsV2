using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int fireFragments;
    public int waterFragments;
    public int windFragments;
    public int rockFragments;

    public GameData()
    {
        this.fireFragments = 0;
        this.waterFragments = 0;
        this.windFragments = 0;
        this.rockFragments = 0;
    }
}
