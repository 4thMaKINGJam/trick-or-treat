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

    public enum Layer
    {
        PlayerDamage = 6,
        MonsterDamage = 7,
    }

    public string PlayerTag = "Player";
}
