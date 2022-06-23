using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARImageTrackingInputHandler : MonoBehaviour
{
    [SerializeField] private ARImageTrackingEventsHandler _arImageTrackingEventsHandler;
    [SerializeField] private UIController _uiController;

    void Update()
    {
        if (WasTapped())
        {
            _arImageTrackingEventsHandler.IsUpdatingTrackedImage = !_arImageTrackingEventsHandler.IsUpdatingTrackedImage;
            _uiController.AdjustTrackingStatusText(_arImageTrackingEventsHandler.IsUpdatingTrackedImage);
        }
    }

    public void ToggleTrackingImageByImageNumber(int imageNumber)
    {
        Debug.Log("Toggling for "+ imageNumber);
    }


    
    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}
