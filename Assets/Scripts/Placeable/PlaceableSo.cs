using UnityEngine;
using UnityEngine.U2D;

public class PlaceableSo : ScriptableObject
{
    [field: SerializeField] public PlaceableDimension PlaceableDimension { get; private set; }
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;
    public Sprite PlaceableSprite => spriteAtlas.GetSprite(spriteName); 
    [field: SerializeField] public Sprite PlaceableSpriteUI { get; private set; }
    
}