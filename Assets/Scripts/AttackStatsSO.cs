using UnityEngine;

[CreateAssetMenu(menuName = "AttackStats")]
public class AttackStatsSO : ScriptableObject
{
    [field: SerializeField] public float AttackDamage { get; private set; } = 10;
    [field: SerializeField] public float AttackRate { get; private set; } = 1;
}