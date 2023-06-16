using UnityEngine;

namespace Tarodev_Pathfinding._Scripts.Grid.Editor
{
    using UnityEditor;
    
    [CustomEditor(typeof(GridManager))]
    public class GridManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GridManager gridManager = (GridManager)target;
            
            using (var h = new EditorGUILayout.HorizontalScope())
            {
                if(GUILayout.Button("Create Grid"))
                    gridManager.CreateGrid();
            
                if(GUILayout.Button("Destroy Grid"))
                    gridManager.DestroyGrid();
            }
        }
    }
}