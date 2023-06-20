using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour, ISoldierTarget
{
    [field: SerializeField] public PlaceableSo PlaceableSo { get; private set; }

    [SerializeField] private SpriteRenderer buildingVisual;

    public List<NodeBase> OccupiedNodes { get; set; }
    public PlaceableDimension Dimension => PlaceableSo.PlaceableDimension;
    
    public BuildingHealth BuildingHealth { get; private set; }

    private void Awake()
    {
        BuildingHealth = GetComponent<BuildingHealth>().Init(this);
    }

    protected virtual void Start()
    {
        buildingVisual.sprite = PlaceableSo.PlaceableSprite;
    }

    public void OnTargetSelected(SoldierUnit soldierUnit)
    {
        NodeBase closestToTarget = OccupiedNodes.GetClosestToTarget(soldierUnit.transform);

        soldierUnit.TargetNode = closestToTarget;
        soldierUnit.SoldierAttackController.SetCurrentTarget(BuildingHealth);
        soldierUnit.SoldierStateController.ChangeState(SoldierState.MoveToTarget);
    }
}