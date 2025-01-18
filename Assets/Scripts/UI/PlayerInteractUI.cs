using System;
using UnityEngine;

namespace UI
{
    public class PlayerInteractUI : MonoBehaviour
    {
        private void Start()
        {   
            HideInteractLabel();
            PlayerInteract.Instance.OnSelectedPaintingChange += Instance_OnSelectedPaintingChange;
        }

        private void Instance_OnSelectedPaintingChange(object sender, PlayerInteract.OnSelectedPaintingChangeEventArgs e)
        {
            if (e.selectedPainting != null)
            {
                ShowInteractLabel();
            }
            else
            {
                HideInteractLabel();
            }
        }

        [SerializeField] private GameObject InteractLabel;

        private void ShowInteractLabel()
        {
            InteractLabel.SetActive(true);
        }

        private void HideInteractLabel()
        {
            InteractLabel.SetActive(false);
        }
        
    }
}
