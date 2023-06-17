using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using UnityEngine;

namespace Tarodev_Pathfinding._Scripts.Grid
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private ScriptableGrid scriptableGrid;
        [SerializeField] private Transform gridParent;

        public Dictionary<Vector2, NodeBase> Nodes { get; private set; }

        public static GridManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            Nodes = new Dictionary<Vector2, NodeBase>();
        }

        private void Start()
        {
            Nodes.Clear();

            var nodes = gridParent.GetComponentsInChildren<NodeBase>();
            if (nodes.Length == 0)
            {
                Debug.LogError("You should create grid first before running the game");
            }

            foreach (NodeBase nodeBase in nodes)
            {
                nodeBase.SetCoords(new SquareCoords() { Pos = nodeBase.transform.position });
                Nodes.Add(nodeBase.Coords.Pos, nodeBase);
            }

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

        #region editorcode

#if UNITY_EDITOR

        [ContextMenu("Clear")]
        public void ClearTiles()
        {
            Nodes.Clear();
        }

        public void CreateGrid()
        {
            DestroyGrid();

            scriptableGrid.GenerateGrid(gridParent);
        }

        public void DestroyGrid()
        {
            Debug.LogError("Destroying existing grid");

            for (int i = this.gridParent.childCount; i > 0; --i)
                DestroyImmediate(gridParent.GetChild(0).gameObject);

            Nodes.Clear();
        }
#endif

        #endregion
    }
}