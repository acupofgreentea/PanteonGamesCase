using _Scripts.Tiles;
using DG.Tweening;
using UnityEngine;

public class SoldierUnit : UnitBase, ISelectable, IInformationDisplayer
{
    [SerializeField] private GameEvent selectableSelectedEvent;
    [field: SerializeField] public InformationMenuInfoSO InformationMenuInfoSo { get; private set; }
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

    private void Start()
    {
        SoldierHealth.OnDie += HandleOnDie;
    }

    private void HandleOnDie()
    {
        CurrentNode = null;
        TargetNode = null;
        transform.DOKill();
    }

    private void OnDestroy()
    {
        SoldierHealth.OnDie -= HandleOnDie;
    }

    public void HandleOnSelected()
    {
        selectableSelectedEvent.Raise();
        SoldierStateController.ChangeState(SoldierState.Idle);
        //ready to move!
    }
}