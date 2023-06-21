using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour, ISoldierTarget, ISelectable, IInformationDisplayer
{
    [SerializeField] private GameEvent selectableSelectedEvent;
    [field: SerializeField] public InformationMenuInfoSO InformationMenuInfoSo { get; private set; }
    [field: SerializeField] public PlaceableSo PlaceableSo { get; private set; }

    [SerializeField] private SpriteRenderer buildingVisual;

    public List<NodeBase> OccupiedNodes { get; set; }
    public PlaceableDimension Dimension => PlaceableSo.PlaceableDimension;
    
    public BuildingHealth BuildingHealth { get; private set; }

    protected virtual void Awake()
    {
        BuildingHealth = GetComponent<BuildingHealth>().Init(this);
    }

    protected virtual void Start()
    {
        buildingVisual.sprite = PlaceableSo.PlaceableSprite;
        BuildingHealth.OnDie += HandleOnDie;
    }

    private void HandleOnDie()
    {
        Debug.LogError("handle on die");
        foreach (NodeBase occupiedNode in OccupiedNodes)
        {
            occupiedNode.IsAvailable = true;
            occupiedNode.Walkable = true;
            occupiedNode.NodeStateController.ChangeState(NodeState.Empty);
        }
        
        OccupiedNodes.Clear();
    }

    public void OnTargetSelected(SoldierUnit soldierUnit)
    {
        List<NodeBase> allNeighbors = new List<NodeBase>();
        
        foreach (NodeBase occupiedNode in OccupiedNodes)
            allNeighbors.AddRange(occupiedNode.Neighbors.FindAll(x=> x.IsAvailable && x.Walkable));

        NodeBase closestToTarget = allNeighbors.GetClosestToTarget(soldierUnit.transform);
        
        soldierUnit.TargetNode = closestToTarget;
        soldierUnit.SoldierAttackController.SetCurrentTarget(BuildingHealth);
        soldierUnit.SoldierStateController.ChangeState(SoldierState.MoveToTarget);
    }

    private void OnDestroy()
    {
        BuildingHealth.OnDie -= HandleOnDie;
    }

    public void HandleOnSelected()
    {        
        selectableSelectedEvent.Raise();
    }

}