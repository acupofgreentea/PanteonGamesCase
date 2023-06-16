using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEditor;
using UnityEngine;

namespace Tarodev_Pathfinding._Scripts.Grid.Scriptables
{
    [CreateAssetMenu(fileName = "New Scriptable Square Grid")]
    public class ScriptableSquareGrid : ScriptableGrid
    {
        [SerializeField, Range(3, 50)] private int _gridWidth = 16;
        [SerializeField, Range(3, 50)] private int _gridHeight = 9;

        public override Dictionary<Vector2, NodeBase> GenerateGrid(Transform parent)
        {
            var tiles = new Dictionary<Vector2, NodeBase>();
            
            float startX = -_gridWidth / 2f + 0.5f;
            float startY = -_gridHeight / 2f + 0.5f;

            for (int x = 0; x < _gridWidth; x++)
            {
                for (int y = 0; y < _gridHeight; y++)
                {
                    var xPos = startX + x;
                    var yPos = startY + y;

                    NodeBase tile = (NodeBase)PrefabUtility.InstantiatePrefab(nodeBasePrefab, parent);
                    tile.Init(DecideIfObstacle(), changeColor, new SquareCoords { Pos = new Vector3(xPos, yPos) });
                    tiles.Add(new Vector2(xPos, yPos), tile);
                }
            }

            return tiles;
        }
    }
}