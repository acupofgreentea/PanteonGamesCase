using UnityEngine;

[CreateAssetMenu(fileName = "HealthSO", menuName = "Health/HealthSO")]
public class HealthSO : ScriptableObject
{
     [field: SerializeField] public float MaxHealth { get; private set; }
}
