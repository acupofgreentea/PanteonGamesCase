using _Scripts.Tiles;
using UnityEngine;

public class SoldierUnit : UnitBase
{
    [field: SerializeField] public NodeBase CurrentNode { get; private set; }
    [field: SerializeField] public NodeBase TargetNode { get; private set; }
    public SoldierStateController SoldierStateController { get; private set; }

    private void Awake()
    {
        SoldierStateController = GetComponent<SoldierStateController>().Init(this);
    }
}