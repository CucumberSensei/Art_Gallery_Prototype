using System;
using UnityEngine;

namespace UI
{
    public class PaintingInteractInfoUI : MonoBehaviour
    {   
        [SerializeField] private PaintingInfoTemplate paintingInfoTemplate;

        private float showTimer;
        private float showTimerMax = 1f;
        
        private void Start()
        {
            PlayerInteract.Instance.OnInteracting += Instance_OnInteracting;
            Hide();
        }

        private void Update()
        {
            if (!PlayerInteract.Instance.IsInteracting())
            {
                return;
            }
            
            showTimer -= Time.deltaTime;
            if (showTimer <= 0f)
            {
                Show(PlayerInteract.Instance.GetSelectedPainting());
            }
        }
        
        private void Instance_OnInteracting(object sender, EventArgs e)
        {   
            bool interacting = PlayerInteract.Instance.IsInteracting();
            if (interacting)
            {
                showTimer = showTimerMax;
            }
            else
            {
                Hide();
            }
        }

        private void Show(Painting painting)
        {   
            paintingInfoTemplate.SetInfo(painting.paintingInfo);
            paintingInfoTemplate.gameObject.SetActive(true);
        }

        private void Hide()
        {   
            paintingInfoTemplate.gameObject.SetActive(false);
        }
    }
}
