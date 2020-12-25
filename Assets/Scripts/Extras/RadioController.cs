using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    public float[] stations;
    private int currentStation;
    public Text station;
    public bool canInteract;

    void Start()
    {
        stations = new float[5];
        stations[0] = 12.5f;
        
        currentStation = 0;
    }

    void Update()
    {
        station.text = "FM-" + stations[currentStation];
        NoteOne();
    }

    public void NextStation()
    {
        currentStation++;
        if(currentStation > 4)
        {
            currentStation = 0;
        }
    }

    public void PreviousStation()
    {
        currentStation--;
        if (currentStation < 0)
        {
            currentStation = 4;
        }
    }

    public void RadioPowerOn()
    {
        Debug.Log("Power On");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Interactable"))
        {
            canInteract = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            canInteract = false;
        }
    }

    public void NoteOne()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            stations[1] = 15.3f;
        }
    }
}
