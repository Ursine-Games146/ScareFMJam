using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience_Tension : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        AkSoundEngine.SetRTPCValue("Tension", dist);
    }
}
