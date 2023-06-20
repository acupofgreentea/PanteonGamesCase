using UnityEngine;
using UnityEngine.UI;

public class ProductionItemUI : MonoBehaviour
{
    private Image image;

    [SerializeField] private PlaceableSo placeableSo;
    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = placeableSo.PlaceableSprite;
    }
}