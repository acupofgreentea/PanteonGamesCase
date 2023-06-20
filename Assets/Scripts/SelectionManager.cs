using _Scripts.Tiles;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }
    public UnityAction<NodeBase, ISelectable> OnTargetNodeSelected { get; set; }

    private Camera cam;

    private Transform lastSelected;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        cam = Camera.main;
        Instance = this;
    }

    private void Update()
    {
        HandleLeftClick();
        HandleRightClick();
    }
    
    private void HandleRightClick()
    {
        if (!Input.GetMouseButtonDown(1))
            return;   
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(lastSelected == null)
            return;
        
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == null)
            return;
        
        if (!hit.transform.TryGetComponent(out ISoldierTarget soldierTarget))
            return;

        if (!lastSelected.TryGetComponent(out SoldierUnit soldierUnit))
            return;
        
        soldierTarget.OnTargetSelected(soldierUnit);
    }

    private void HandleLeftClick()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        Vector3 inputPosition = Input.mousePosition;
        
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(inputPosition), Vector2.zero);

        if (hit.collider == null) 
            return;

        if (!hit.transform.TryGetComponent(out ISelectable selectable))
            return;
        
        lastSelected = hit.transform;
        selectable.HandleOnSelected();
    }
}
