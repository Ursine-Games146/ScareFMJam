using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newThreatData", menuName = "Data/Threat Data/Base Data")]
public class ThreatData : ScriptableObject
{
    public float moveSpeed = 5.0f;
    public float runSpeed = 7.0f;
}
