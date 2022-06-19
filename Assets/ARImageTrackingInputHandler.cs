using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARImageTrackingInputHandler : MonoBehaviour
{
    [SerializeField] private ARImageTrackingEventsHandler _arImageTrackingEventsHandler;
    [SerializeField] private TMP_Text trackingStatusText;

    private void Start()
    {
        AdjustTrackingStatusText(_arImageTrackingEventsHandler.IsUpdatingTrackedImage);
    }

    void Update()
    {
        if (WasTapped())
        {
            _arImageTrackingEventsHandler.IsUpdatingTrackedImage = !_arImageTrackingEventsHandler.IsUpdatingTrackedImage;
            AdjustTrackingStatusText(_arImageTrackingEventsHandler.IsUpdatingTrackedImage);
        }
    }

    private void AdjustTrackingStatusText(Boolean isTracking)
    {
        if (isTracking)
            trackingStatusText.text = "Tracking";
        else
            trackingStatusText.text = "Not Tracking";
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
