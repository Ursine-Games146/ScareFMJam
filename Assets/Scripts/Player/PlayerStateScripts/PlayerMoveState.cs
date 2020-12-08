using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, CharacterStateController stateController, PlayerData playerData, string animBoolName) : 
        base(player, stateController, playerData, animBoolName)
    {
    }
}
