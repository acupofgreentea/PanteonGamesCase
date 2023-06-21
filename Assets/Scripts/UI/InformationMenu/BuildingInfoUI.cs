using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buildingNameText;
    [SerializeField] private Image buildingImage;

    private void Start()
    {
        SetActivePanel(false);
    }

    public void Setup()
    {  
        SetActivePanel(false);
        Transform selectable = SelectionManager.Instance.LastSelected;

        if (!selectable.TryGetComponent(out IInformationDisplayer informationDisplayer))
            return;
        
        SetActivePanel(true);
        buildingNameText.text = informationDisplayer.InformationMenuInfoSo.Name;
        buildingImage.sprite = informationDisplayer.InformationMenuInfoSo.Sprite;
        buildingImage.SetNativeSize();
    }

    private void SetActivePanel(bool enable)
    {
        buildingNameText.gameObject.SetActive(enable);
        buildingImage.gameObject.SetActive(enable);
    }
}