using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    [field: SerializeField] public PlaceableSo PlaceableSo { get; private set; }

    [SerializeField] private SpriteRenderer buildingVisual;

    public PlaceableDimension Dimension => PlaceableSo.PlaceableDimension;

    protected virtual void Start()
    {
        buildingVisual.sprite = PlaceableSo.PlaceableSprite;
    }

    public bool IsAbleToBuild(NodeBase currentNode)
    {
        Vector2[] directions = currentNode.GetDirectionByDimension(Dimension);

        List<NodeBase> list = GridSelectionManager.Instance.GetNodesAtDirections(currentNode, directions);

        list.Add(currentNode);

        if (list.Any(x => x.IsAvailable == false))
            return false;

        if (list.Count - 1 == directions.Length)
            return false;

        foreach (NodeBase nodeBase in list)
            nodeBase.IsAvailable = false;

        return true;
    }
}