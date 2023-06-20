using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingProductionUI", menuName = "BuildingProductionUI")]
public class BuildingProductionUISO : ScriptableObject
{
    [field: SerializeField] public List<Production> Productions { get; private set; }
}

[System.Serializable]
public class Production
{
    [field: SerializeField] public Sprite ProductionSprite { get; private set; }
}