using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LastPaintingTemplate : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI authorText;
        
        public void SetInfo(Painting painting)
        {
            image.sprite = painting.paintingImage.sprite;
            titleText.text = painting.paintingInfo.title;
            authorText.text = painting.paintingInfo.author;
        }
        
    }
}
