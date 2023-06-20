using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;

    [SerializeField] private UnityEvent response;

    private void Start()
    {
        if (gameEvent != null)
        {
            gameEvent.AddListener(this);
        }
    }

    private void OnDisable()
    {
        if (gameEvent != null)
        {
            gameEvent.RemoveListener(this);
        }
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}