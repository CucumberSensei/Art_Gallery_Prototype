using System;
using UnityEngine;
using System.Collections;
using System.IO;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private Painting[] paintingPrefabArray;
    [SerializeField] private PaintingInfo[] paintingInfoArray;
    
    private string jsonFilePath = Application.dataPath + "/GalleryData/paintings.json";

    private void Awake()
    {
       LoadGalleryData();
    }

    private void Start()
    {
        LoadPaintingsTexture();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadPaintingsTexture();
        }
    }

    private void LoadGalleryData()
    {
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError("JSON file not found in: " + jsonFilePath); return; 
        }
        
        string json = File.ReadAllText(jsonFilePath);
        
        GalleryData galleryData = JsonUtility.FromJson<GalleryData>(json);
        paintingInfoArray = galleryData.paintings;

        foreach (Painting painting in paintingPrefabArray)
        {
            foreach (PaintingInfo paintingInfo in paintingInfoArray)
            {
                if (painting.prefabID == paintingInfo.id)
                {
                    painting.paintingInfo = paintingInfo;
                }
            }
        }
    }

    private void LoadPaintingsTexture()
    {
        foreach (Painting painting in paintingPrefabArray)
        {
            painting.LoadImageFromFile(painting.paintingInfo.image);
        }
    }
}
