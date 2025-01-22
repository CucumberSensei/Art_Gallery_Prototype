using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Painting : MonoBehaviour
{
    public Transform interactCameraFollowTransform;
    public Transform interactCameraLookAtTransform;
    public int prefabID;
    public PaintingInfo paintingInfo;
    
    public Image paintingImage;
    
    public void LoadImageFromFile(string imageName)
    {
        string imagePath = Path.Combine(Application.dataPath, "GalleryData", imageName);
        if (File.Exists(imagePath))
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            
            Texture2D texture = new Texture2D(2, 2); 
            texture.LoadImage(imageData); 
            
            
            float pixelsPerUnit = 100.0f;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit); 
            paintingImage.sprite = sprite;
        }
    }
}
