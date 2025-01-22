using System;
using UnityEngine;

namespace UI
{
    public class LastPaintingUI : MonoBehaviour
    {
        [SerializeField] private LastPaintingTemplate lastPaintingTemplate;

        private void Start()
        {
            PlayerInteract.Instance.OnInteracting += Instance_OnInteracting;
            Hide();
        }

        private void Instance_OnInteracting(object sender, EventArgs e)
        {   
            lastPaintingTemplate.SetInfo(PlayerInteract.Instance.GetSelectedPainting());
            
            bool interacting = PlayerInteract.Instance.IsInteracting();
            if (interacting)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void Show()
        {
            lastPaintingTemplate.gameObject.SetActive(true);
        }

        private void Hide()
        {
            lastPaintingTemplate.gameObject.SetActive(false);
        }
        
    }
}
