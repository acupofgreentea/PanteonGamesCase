using UnityEngine;
using UnityEngine.Serialization;

public class PlaceableSo : ScriptableObject
{
    [field: SerializeField] public string PlaceableName { get; private set; }
    [field: SerializeField] public PlaceableDimension PlaceableDimension { get; private set; }
    [field: SerializeField] public Sprite PlaceableSprite { get; private set; }
    [field: SerializeField] public Sprite PlaceableSpriteUI { get; private set; }
    
}