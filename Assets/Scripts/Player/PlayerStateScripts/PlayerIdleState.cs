using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : 
        base(player, stateController, playerData, animBoolName)
    {
    }
}
