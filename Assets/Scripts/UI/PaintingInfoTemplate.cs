using TMPro;
using UnityEngine;

namespace UI
{
    public class PaintingInfoTemplate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI authorText;
        [SerializeField] private TextMeshProUGUI yearText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        
        
        public void SetInfo(PaintingInfo paintingInfo)
        {
            titleText.text = paintingInfo.title;
            authorText.text = paintingInfo.author;
            yearText.text = paintingInfo.year.ToString();
            descriptionText.text = paintingInfo.description;
        }
    }
}
