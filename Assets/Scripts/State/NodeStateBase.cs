using _Scripts.Tiles;

public abstract class NodeStateBase
{
    protected NodeBase nodeBase;
    
    public NodeStateBase(NodeBase nodeBase)
    {
        this.nodeBase = nodeBase;
    }

    public abstract void HandleNodeSelected();
}