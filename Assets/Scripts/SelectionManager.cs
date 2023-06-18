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
        RaycastHit2D hit = Physics2D.Raycast(finger.GetWorldPosition(0f), Vector2.zero);

        if(finger.IsOverGui)
            return;
        
        if (hit.collider == null) 
            return;

        if (!hit.transform.TryGetComponent(out ISelectable selectable))
            return;
        
        selectable.HandleOnSelected();
    }

    private void OnDestroy()
    {
        LeanTouch.OnFingerDown -= HandleFingerDown;
    }
}