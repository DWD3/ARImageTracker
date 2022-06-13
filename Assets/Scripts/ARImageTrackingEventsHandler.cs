using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARImageTrackingEventsHandler : MonoBehaviour
{

    private ARTrackedImageManager _arTrackedImageManager;

    [SerializeField] private GameObject _prefebToSpawnOnImage;

    private GameObject _currentlyTrackedImagePrefab;
    
    void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }
    
    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs e)
    {
        foreach (var imageAdded in e.added)
        {
            var imageTransform = imageAdded.transform;
            _currentlyTrackedImagePrefab = Instantiate(_prefebToSpawnOnImage, imageTransform.position,imageTransform.rotation);
        }
        
        foreach (var imageAdded in e.updated)
        {
            Debug.Log("Updated: " + imageAdded.transform.position);
            var imageTransform = imageAdded.transform;
            _currentlyTrackedImagePrefab.transform.position = imageTransform.position;
            _currentlyTrackedImagePrefab.transform.rotation = imageTransform.rotation;
        }
        
        foreach (var imageAdded in e.removed)
        {
            Debug.Log("Removed: " + imageAdded.referenceImage.name);
            Destroy(_currentlyTrackedImagePrefab);
            _currentlyTrackedImagePrefab = null;
        }
        
    }
}
