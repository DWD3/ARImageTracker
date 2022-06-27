using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private List<TMP_Text> trackingButtonText;

    private void Start()
    {
        for (var i = 0; i < trackingButtonText.Count; i++)
        {
            trackingButtonText[i].text = "Lock QR" + (i + 1);
        }
    }

    public void toggleButtonTextBasedOnTracking(int imageNumber, bool isTracking)
    {
        
        if(isTracking)
            trackingButtonText[imageNumber-1].text = "Lock QR" + imageNumber;
        else
            trackingButtonText[imageNumber-1].text = "Unlock QR" + imageNumber;
    }
    
}
