using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Tiles
{
    public abstract class NodeBase : MonoBehaviour, ISelectable
    {
        [Header("References")] [SerializeField]
        private Color _obstacleColor;

        [SerializeField] private Gradient _walkableColor;
        [SerializeField] protected SpriteRenderer _renderer;

        public ICoords Coords;
        
        public bool Walkable { get; private set; }
        private Color _defaultColor;

        public bool IsAvailable { get; set; } = true;
        
        public NodeStateController NodeStateController { get; private set; }

        private void Awake()
        {
            NodeStateController = GetComponent<NodeStateController>().Init(this);
        }


        public virtual void Init(bool walkable, bool changeColor, ICoords coords)
        {
            Walkable = walkable;

            _renderer.color = walkable
                ? changeColor ? _walkableColor.Evaluate(Random.Range(0f, 1f)) : _walkableColor.Evaluate(1f)
                : _obstacleColor;
            
            _defaultColor = _renderer.color;
            
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

        public void SetColor(Color color) => _renderer.color = color;

        public void RevertTile()
        {
            _renderer.color = _defaultColor;
        }

        #endregion
    }
}

public interface ICoords
{
    public float GetDistance(ICoords other);
    public Vector2 Pos { get; set; }
}