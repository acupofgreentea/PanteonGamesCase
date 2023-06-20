using UnityEngine;

[CreateAssetMenu(menuName = "Soldier Spawn Stat")]
public class BuildingSoldierSpawnStatSO : ScriptableObject
{
    [field: SerializeField] public float SpawnRate = 5f;
    [field: SerializeField] public int MaxCount = 3;
}