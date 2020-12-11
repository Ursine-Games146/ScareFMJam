using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    void PlayFootsteps()
    {
        AkSoundEngine.PostEvent("Play_Footsteps", mainCamera);
    }    
}
