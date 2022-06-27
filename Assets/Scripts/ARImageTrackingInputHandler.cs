using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARImageTrackingInputHandler : MonoBehaviour
{
    [SerializeField] private ARImageTrackingEventsHandler _arImageTrackingEventsHandler;
    [SerializeField] private UIController _uiController;

    public void ToggleTrackingImageByImageNumber(int imageNumber)
    {
        _arImageTrackingEventsHandler.ToggleTrackingForImage("QR"+imageNumber);
        if (_arImageTrackingEventsHandler.ImageNameToIsTrackingDict.ContainsKey("QR" + imageNumber))
        {
            _uiController.toggleButtonTextBasedOnTracking(imageNumber,
                _arImageTrackingEventsHandler.ImageNameToIsTrackingDict["QR" + imageNumber]);
        }
        else
            _uiController.toggleButtonTextBasedOnTracking(imageNumber,true);
        

    }
    
}
