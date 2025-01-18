using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{   
    public static PlayerInteract Instance{get; private set;}
    
    [SerializeField] private float heightOffset = 2f;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask paintingLayerMask;
    [SerializeField] private Painting selectedPainting;

    public event EventHandler<OnSelectedPaintingChangeEventArgs> OnSelectedPaintingChange;
    public class OnSelectedPaintingChangeEventArgs : EventArgs
    {
        public Painting selectedPainting;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There more than one Player Instance");
        }
        Instance = this;
    }

    private void Update()
    {   
        HandlePaintingSelection();
    }
    
    public void OnInteract()
    {
        Debug.Log("Interact");
    }

    private void HandlePaintingSelection()
    {
        if (Physics.Raycast(transform.position + Vector3.up * heightOffset, transform.forward,
                out RaycastHit hit, interactDistance, paintingLayerMask))
        {
            
            
            if (hit.transform.TryGetComponent<Painting>(out Painting painting))
            {
                if (selectedPainting != painting)
                {
                    SetSelectedPainting(painting);
                }
            }
        }
        else
        {
            SetSelectedPainting(null);
        }
    }
    
    private void SetSelectedPainting(Painting painting)
    {
        selectedPainting = painting;
        OnSelectedPaintingChange?.Invoke(this, new OnSelectedPaintingChangeEventArgs
        {
            selectedPainting = painting
        });
    }
}
