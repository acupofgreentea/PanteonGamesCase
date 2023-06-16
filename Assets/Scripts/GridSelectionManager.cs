using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using UnityEngine;
using UnityEngine.Events;
using Lean.Touch;

public class GridSelectionManager : MonoBehaviour
{
    public static GridSelectionManager Instance;
    public Dictionary<Vector2, NodeBase> Nodes { get; private set; }
    
    public NodeBase CurrentNode { get; private set; }

    public UnityAction<NodeBase> OnNodeSelected { get; set; }

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

        if (!hit.transform.TryGetComponent(out NodeBase nodeBase))
            return;
        
        if(nodeBase.IsAvailable == false)
            return;
        
        CurrentNode = nodeBase;

        OnNodeSelected?.Invoke(nodeBase);
    }

    public void SetTiles(Dictionary<Vector2, NodeBase> dic)
    {
        Nodes = dic;

        foreach (var tile in Nodes.Values)
            tile.CacheNeighbors();
    }

    public NodeBase GetNodeAtPosition(Vector2 pos) => Nodes.TryGetValue(pos, out var node) ? node : null;
    
    public List<NodeBase> GetNodesAtDirections(NodeBase node, Vector2[] dir)
    {
        List<NodeBase> nodes = new List<NodeBase>();

        foreach (Vector2 currentDir in dir)
        {
            nodes.AddRange(Nodes.Values.Where(nodeBase => nodeBase.Coords.Pos == node.Coords.Pos + currentDir));
        }

        return nodes;
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

public enum PlayState
{
    Build,
    Unit,
}