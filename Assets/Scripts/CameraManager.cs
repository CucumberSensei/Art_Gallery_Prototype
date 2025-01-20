using System;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera interactCamera;
    
    private void Start()
    {
        PlayerInteract.Instance.OnInteracting += Instance_OnInteracting;
    }

    private void Instance_OnInteracting(object sender, EventArgs e)
    {   
        bool isInteracting = PlayerInteract.Instance.IsInteracting();
        Painting painting = PlayerInteract.Instance.GetSelectedPainting();
        
        if (isInteracting)
        {   
            ShowInteractCamera(painting);
        }
        else
        {
            HideInteractCamera();
        }
    }

    private void ShowInteractCamera(Painting painting)
    {
        interactCamera.Follow = painting.interactCameraFollowTransform;
        interactCamera.LookAt = painting.interactCameraLookAtTransform;
        interactCamera.gameObject.SetActive(true);
    }

    private void HideInteractCamera()
    {
        interactCamera.gameObject.SetActive(false);
    }
}


