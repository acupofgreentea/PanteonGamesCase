using System.Collections.Generic;
using _Scripts.Tiles;

public class NodeStateController : StateControllerBase<NodeState, NodeStateBase>
{
    private NodeBase nodeBase;
    
    public NodeStateController Init(NodeBase nodeBase)
    {
        this.nodeBase = nodeBase;
        CreateDictionary();
        ChangeState(NodeState.Empty);
        
        return this;
    }


    protected override void CreateDictionary()
    {
        stateDictionary = new Dictionary<NodeState, NodeStateBase>
        {
            { NodeState.Unit , new UnitNodeState(nodeBase)},
            { NodeState.Empty, new EmptyNodeState(nodeBase)},
            { NodeState.Building, new BuildingNodeState(nodeBase)},
        };    
    }

    public void HandleOnNodeSelected()
    {
        CurrentState.HandleNodeSelected();
    }
}