using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "InformationMenuInfoSO", menuName = "InformationMenuInfoSO")]
public class InformationMenuInfoSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
     public Sprite Sprite => spriteAtlas.GetSprite(spriteName);
    
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;
}