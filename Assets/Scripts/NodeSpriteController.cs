using _Scripts.Tiles;
using DG.Tweening;
using UnityEngine;

public class NodeSpriteController : MonoBehaviour
{
    [Header("References")]
    
    [SerializeField] private Color _obstacleColor;
    [SerializeField] private Gradient _walkableColor;
    [SerializeField] protected SpriteRenderer _renderer;
    
    private Color _defaultColor;

    private NodeBase nodeBase;

    public Color GetCurrentColor => _renderer.color;
    public Color GetDefaultColor => _defaultColor;
    
    public void ChangeNodeColor(Color targetColor)
    {
        _renderer.color = targetColor;
    }
        
    public void ChangeNodeColor(Color targetColor, float duration)
    {
        _renderer.DOColor(targetColor, duration);
    }

    public NodeSpriteController Init(NodeBase nodeBase)
    {
        this.nodeBase = nodeBase;
        
        _defaultColor = _renderer.color;

        return this;
    }

    public void InitNodeColor(bool walkable, bool changeColor)
    {
        ChangeNodeColor(walkable
            ? changeColor ? _walkableColor.Evaluate(Random.Range(0f, 1f)) : _walkableColor.Evaluate(1f)
            : _obstacleColor);
    }
}