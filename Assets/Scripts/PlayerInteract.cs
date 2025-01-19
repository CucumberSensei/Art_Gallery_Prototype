using System;
using StarterAssets;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{   
    public static PlayerInteract Instance{get; private set;}
    
    [SerializeField] private float heightOffset = 2f;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask paintingLayerMask;
    [SerializeField] private Painting selectedPainting;
    [SerializeField] private bool isInteracting;
    
    public event EventHandler OnSelectedPaintingChange;
    public event EventHandler OnInteracting; 
    

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
        if (selectedPainting != null)
        {   
            isInteracting = !isInteracting;
            OnInteracting?.Invoke(this, EventArgs.Empty);
        }
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
        OnSelectedPaintingChange?.Invoke(this, EventArgs.Empty);
    }

    public Painting GetSelectedPainting()
    {
        return selectedPainting;
    }

    public bool IsInteracting()
    {
        return isInteracting;
    }
}
