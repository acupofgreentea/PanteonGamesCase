using _Scripts.Tiles;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private NodeBase lastSelectedNode;
    
    private void Start()
    {
        GridSelectionManager.Instance.OnNodeSelected += HandleNodeSelected;
        UIManager.Instance.ProductionMenuUI.OnProductionSelected += HandleProductionSelected;
    }

    private void HandleProductionSelected(ProductionItemUI productionItem)
    {
    
    }

    private void HandleNodeSelected(NodeBase node)
    {
        //if production is selected check build 
        //if node selected
    }

    private void OnDestroy()
    {
        GridSelectionManager.Instance.OnNodeSelected -= HandleNodeSelected;
    }
}