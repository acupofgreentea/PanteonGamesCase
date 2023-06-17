using _Scripts.Tiles;
using UnityEngine;

public class UnitNodeState : NodeStateBase
{
    public UnitNodeState(NodeBase nodeBase) : base(nodeBase)
    {
        
    }

    public override void HandleNodeSelected()
    {
        Debug.Log("UnitNodeState");
    }
}