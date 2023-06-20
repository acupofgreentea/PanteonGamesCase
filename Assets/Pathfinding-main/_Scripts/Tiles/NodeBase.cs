using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Tiles
{
    public abstract class NodeBase : MonoBehaviour, ISelectable, ISoldierTarget
    {
        public ICoords Coords;
        public bool Walkable { get; set; }
        public bool IsAvailable { get; set; } = true;
        public NodeStateController NodeStateController { get; private set; }
        public NodeSpriteController NodeSpriteController { get; private set; }

        
        private void Awake()
        {
            NodeStateController = GetComponent<NodeStateController>().Init(this);
            NodeSpriteController = GetComponent<NodeSpriteController>().Init(this);
            Walkable = true;
            IsAvailable = true;
        }

        public virtual void Init(bool walkable, bool changeColor, ICoords coords)
        {
            Walkable = walkable;
            NodeSpriteController ??= GetComponent<NodeSpriteController>().Init(this);
            NodeSpriteController.InitNodeColor(walkable, changeColor);
            SetCoords(coords);
        }

        public float GetDistance(NodeBase other) =>
            Coords.GetDistance(other.Coords); // Helper to reduce noise in pathfinding
        
        public virtual void SetCoords(ICoords coords)
        {
            Coords = coords;
            transform.position = Coords.Pos;
        }
        
        public void HandleOnSelected()
        {
            NodeStateController.HandleOnNodeSelected();
        }
        
        public void OnTargetSelected(SoldierUnit soldierUnit)
        {
            soldierUnit.TargetNode = this;
            soldierUnit.SoldierAttackController.SetCurrentTarget(null);
            soldierUnit.SoldierStateController.ChangeState(SoldierState.MoveToTarget);
        }

        #region Pathfinding

        public List<NodeBase> Neighbors { get; protected set; }
        public NodeBase Connection { get; private set; }
        public float G { get; private set; }
        public float H { get; private set; }
        public float F => G + H;

        public abstract void CacheNeighbors();

        public void SetConnection(NodeBase nodeBase)
        {
            Connection = nodeBase;
        }
        public void SetG(float g)
        {
            G = g;
        }

        public void SetH(float h)
        {
            H = h;
        }

        #endregion

    }
}

public interface ICoords
{
    public float GetDistance(ICoords other);
    public Vector2 Pos { get; set; }
}