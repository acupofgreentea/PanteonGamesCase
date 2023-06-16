using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEngine;

public static class DimensionDictionary
{
    private static readonly Dictionary<PlaceableDimension, Vector2[]> dimensionDic = new Dictionary<PlaceableDimension, Vector2[]>()
    {
        { PlaceableDimension.OneByOne, new []{Vector2.zero }},
        { PlaceableDimension.TwoByThree, new []{ Vector2.right, Vector2.up, Vector2.down, Vector2.right + Vector2.up, Vector2.right + Vector2.down}},
        { PlaceableDimension.FourByFour, new []{ Vector2.up, Vector2.right, Vector2.right + Vector2.up }}
    };

    public static Vector2[] GetDirectionByDimension(this NodeBase nodeBase, PlaceableDimension dimension)
    {
        return dimensionDic[dimension];
    }
    
    public static Vector2 GetPositionByDimension(this NodeBase nodeBase, PlaceableDimension dimension)
    {
        Vector2 nodePos = nodeBase.transform.position;
        
        switch (dimension)
        {
            case PlaceableDimension.OneByOne:
                return nodePos;
            
            case PlaceableDimension.FourByFour:
                nodePos += Vector2.one * 0.5f;
                return nodePos;
            
            case PlaceableDimension.TwoByThree:
                nodePos += Vector2.right * 0.5f;
                return nodePos;
            
            default:
                return nodePos;
        }
    }
}