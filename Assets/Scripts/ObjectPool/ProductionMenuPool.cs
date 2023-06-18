using UnityEngine;

public class ProductionMenuPool : MonoBehaviour
{
    [SerializeField] private ProductionItemUI productionItemUI;
    [SerializeField] private int initialCount = 5;
    [SerializeField] private Transform poolParent;
    
    private ObjectPool<ProductionItemUI> pool;
    
    private void Awake()
    {
        pool = new ObjectPool<ProductionItemUI>(poolParent, productionItemUI, initialCount);
    }
    
    public ProductionItemUI Get()
    {
        return pool.Get();
    }
    
    public void ReturnToPool(ProductionItemUI productionItemUI)
    {
        pool.ReturnToPool(productionItemUI);
    }
}