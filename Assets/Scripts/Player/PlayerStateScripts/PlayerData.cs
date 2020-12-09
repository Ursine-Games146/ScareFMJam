using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed = 7.0f;
    public float runSpeed = 10.0f;
    public float climbSpeed = 5.0f;
    public float maxStamina = 2.0f;
    public float currentStamina;
}
