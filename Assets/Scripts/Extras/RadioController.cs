using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    public float[] stations;
    private int currentStation;
    public Text station;

    void Start()
    {
        stations = new float[5];
        stations[0] = 12.5f;
        stations[1] = 15.3f;
        stations[2] = 18.8f;
        stations[3] = 21.0f;
        stations[4] = 23.2f;

        currentStation = 0;
    }

    void Update()
    {
        station.text = "FM-" + stations[currentStation];
    }

    public void ChangeStations()
    {
        currentStation++;
        if(currentStation > 4)
        {
            currentStation = 0;
        }
    }

    public void RadioPowerOn()
    {

    }
}
