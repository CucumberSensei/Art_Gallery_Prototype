using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject interactCameraGameObject;
    
    

    private void ShowInteractCamera()
    {
        interactCameraGameObject.SetActive(true);
    }

    private void HideInteractCamera()
    {
        interactCameraGameObject.SetActive(false);
    }
}


