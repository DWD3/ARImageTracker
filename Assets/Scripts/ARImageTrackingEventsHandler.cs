using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARImageTrackingEventsHandler : MonoBehaviour
{

    private ARTrackedImageManager _arTrackedImageManager;

    [SerializeField] private GameObject prefebToSpawnOnImage;

    private readonly Dictionary<String,GameObject>  _imageNameToCurrentPrefabObjDictionary =
        new Dictionary<string, GameObject>();
    
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
            var imageName = imageAdded.referenceImage.name;
            _imageNameToCurrentPrefabObjDictionary.Add(imageName,
                Instantiate(prefebToSpawnOnImage, imageTransform.position,imageTransform.rotation));
            var materialColor = _AssignColorToPrefabAccordingToImageName(imageName);
            _imageNameToCurrentPrefabObjDictionary[imageName].GetComponent<Renderer>().material.color = materialColor;
            Debug.Log("Detected image " + imageName);
        }
        
        foreach (var imageAdded in e.updated)
        {
            var imageName = imageAdded.referenceImage.name;
            var imageTransform = imageAdded.transform;
            var prefabObjForImage = _imageNameToCurrentPrefabObjDictionary[imageName];
            prefabObjForImage.transform.position = imageTransform.position;
            prefabObjForImage.transform.rotation = imageTransform.rotation;
        }

        foreach (var imageAdded in e.removed)
        {
            var imageName = imageAdded.referenceImage.name;
            var prefabObjForImage = _imageNameToCurrentPrefabObjDictionary[imageName];
            Destroy(prefabObjForImage);
            _imageNameToCurrentPrefabObjDictionary.Remove(imageName);
            Debug.Log("Removed image prefab for image " + imageName);
        }
    }

    private Color _AssignColorToPrefabAccordingToImageName(String imageName)
    {
        Debug.Log("Calculating Color for /" + imageName+"/");
        if (String.Equals(imageName,"QR1"))
        {
            return Color.blue;
        } 
        if (String.Equals(imageName,"QR2"))
        {
            return Color.red;
        }
        if (String.Equals(imageName,"QR3"))
        {
            return Color.green;
        }
        if (String.Equals(imageName,"QR4"))
        {
            return Color.white;
        }
        return Color.magenta;
    }
}
