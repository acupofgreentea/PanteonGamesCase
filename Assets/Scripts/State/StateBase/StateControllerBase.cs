using System.Collections.Generic;
using UnityEngine;

public abstract class StateControllerBase<T, T1> : MonoBehaviour where T : System.Enum
{
    protected T1 CurrentState { get; private set; }

    protected Dictionary<T, T1> stateDictionary;
    protected abstract void CreateDictionary();

    public virtual void ChangeState(T type)
    {
        CurrentState = stateDictionary.GetValueOrDefault(type);
    }
}