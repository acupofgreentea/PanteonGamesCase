using _Scripts.Tiles;
using UnityEngine;
using Lean.Touch;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        LeanTouch.OnFingerDown += HandleFingerDown;
    }

    private void HandleFingerDown(LeanFinger finger)
    {
        RaycastHit2D hit = Physics2D.Raycast(finger.GetWorldPosition(100f), Vector2.zero);

        if (hit.collider == null) 
            return;

        if (!hit.transform.TryGetComponent(out ISelectable selectable))
            return;
        
        selectable.HandleOnSelected();
    }

    private void OnTileHover(NodeBase nodeBase)
    {
        //var path = Pathfinding.FindPath(startNode, targetNode);
    }

    private void OnDestroy()
    {
        LeanTouch.OnFingerDown -= HandleFingerDown;
    }
}