using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideState : PlayerState
{
    public PlayerHideState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : 
        base(player, stateController, playerData, animBoolName)
    {
    }
}
