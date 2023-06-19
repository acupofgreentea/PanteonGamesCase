using UnityEngine;

[CreateAssetMenu(fileName = "HealthSO", menuName = "Health")]
public class HealthSO : ScriptableObject
{
     [field: SerializeField] public float MaxHealth { get; private set; }
}
