using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Lobby,
        Stage001,
        FinalStage,
        EndingScene
    }

    public enum Attack
    {
        ShortAttack,
        MagicAttack
    }

    public enum Layer
    {
        PlayerDamage = 6,
        MonsterDamage = 7,
        Ground = 8,
    }

    public string PlayerTag = "Player";
}
