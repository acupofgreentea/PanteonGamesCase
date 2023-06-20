using UnityEngine;
using UnityEngine.Events;

public class PoolBase<T> : MonoBehaviour where T : MonoBehaviour 
{
    [SerializeField] private T prefab;
    [SerializeField] private int initialCount = 5;
    [SerializeField] private Transform poolParent;
    
    private ObjectPool<T> pool;
    
    public UnityAction<T> OnReturnToPool { get; set; }
    
    protected virtual void Awake()
    {
        pool = new ObjectPool<T>(poolParent, prefab, initialCount);
    }
    
    public virtual T Get()
    {
        return pool.Get();
    }
    
    public virtual void ReturnToPool(T t)
    {
        OnReturnToPool?.Invoke(t);
        pool.ReturnToPool(t);
    }
}