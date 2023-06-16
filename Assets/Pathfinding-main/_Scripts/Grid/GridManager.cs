using System.Collections.Generic;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using UnityEngine;

namespace Tarodev_Pathfinding._Scripts.Grid
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private ScriptableGrid scriptableGrid;
        [SerializeField] private Transform gridParent;

        private Dictionary<Vector2, NodeBase> tiles = new();

        private void Start()
        {
            tiles.Clear();
            var nodes = gridParent.GetComponentsInChildren<NodeBase>();
            if (nodes.Length == 0)
            {
                Debug.LogError("You should create grid first before running the game");
            }
            
            foreach (NodeBase nodeBase in nodes)
            {
                nodeBase.SetCoords(new SquareCoords(){Pos = nodeBase.transform.position});
                tiles.Add(nodeBase.Coords.Pos, nodeBase);
            }

            GridSelectionManager.Instance.SetTiles(tiles);
        }

#if UNITY_EDITOR

        [ContextMenu("Clear")]
        public void ClearTiles()
        {
            tiles.Clear();
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

            tiles.Clear();
        }
#endif
    }
}