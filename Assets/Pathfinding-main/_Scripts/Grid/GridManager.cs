using System.Collections.Generic;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using UnityEngine;

namespace Tarodev_Pathfinding._Scripts.Grid
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance;

        [SerializeField] private ScriptableGrid scriptableGrid;

        public Dictionary<Vector2, NodeBase> Tiles { get; private set; }

        private NodeBase startNode, targetNode;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }
        
        private void Start()
        {
            Tiles = scriptableGrid.GenerateGrid();

            foreach (var tile in Tiles.Values) 
                tile.CacheNeighbors();

            NodeBase.OnHoverTile += OnTileHover;
        }

        public NodeBase GetTileAtPosition(Vector2 pos) => Tiles.TryGetValue(pos, out var tile) ? tile : null;
        
        private void OnTileHover(NodeBase nodeBase)
        {
            foreach (var t in Tiles.Values) 
                t.RevertTile();

            var path = Pathfinding.FindPath(startNode, targetNode);
        }
        
        
        private void OnDestroy() => NodeBase.OnHoverTile -= OnTileHover;
    }
}