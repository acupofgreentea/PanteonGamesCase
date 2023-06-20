using UnityEngine;
using UnityEngine.UI;

public class BuildingProductionItemUI : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Init(Sprite sprite)
    {
        image ??= GetComponent<Image>();
        
        image.sprite = sprite;
    }
}