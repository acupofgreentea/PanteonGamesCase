using UnityEngine;

[CreateAssetMenu(fileName = "InformationMenuInfoSO", menuName = "InformationMenuInfoSO")]
public class InformationMenuInfoSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}