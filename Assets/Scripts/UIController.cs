using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private TMP_Text trackingStatusText;

    private void Start()
    {
        AdjustTrackingStatusText(false);
    }

    public void AdjustTrackingStatusText(bool isTracking)
    {
        trackingStatusText.text = isTracking ? "Tracking" : "Not Tracking";
    }
}
