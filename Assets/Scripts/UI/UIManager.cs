using UnityEngine;

public class UIManager : MonoBehaviour
{
    [field: SerializeField] public ProductionMenuUI ProductionMenuUI { get; private set; }
    
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }
}