using UnityEngine;

public class PlaceableSo : ScriptableObject
{
    [SerializeField] private string placeableName;
    
    [field: SerializeField] public PlaceableDimension PlaceableDimension { get; private set; }
    [field: SerializeField] public Sprite PlaceableSprite { get; private set; }
    
}