using _Scripts.Tiles;
using UnityEngine;

public class SoldierUnit : UnitBase, ISelectable
{
    [field: SerializeField] public NodeBase CurrentNode { get; set; }
    [field: SerializeField] public NodeBase TargetNode { get; set; }
    public SoldierStateController SoldierStateController { get; private set; }
    public SoldierAttackController SoldierAttackController { get; private set; }
    public SoldierHealth SoldierHealth { get; private set; }

    private void Awake()
    {
        SoldierStateController = GetComponent<SoldierStateController>().Init(this);
        SoldierAttackController = GetComponent<SoldierAttackController>().Init(this);
        SoldierHealth = GetComponent<SoldierHealth>().Init(this);
    }

    public void HandleOnSelected()
    {
        SoldierStateController.ChangeState(SoldierState.Idle);
        //ready to move!
    }
}