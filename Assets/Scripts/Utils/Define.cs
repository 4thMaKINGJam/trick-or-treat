using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Lobby,
        StartScene,
        TitleScene,
        Stage001,
        Stage002,
        BossScene,
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
        Dead = 9,
    }

    public string PlayerTag = "Player";
}
