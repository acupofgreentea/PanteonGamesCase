using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour, ISoldierTarget, ISelectable
{
    [SerializeField] private GameEvent selectableSelectedEvent;
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

    public void HandleOnSelected()
    {        
        selectableSelectedEvent.Raise();
    }
}