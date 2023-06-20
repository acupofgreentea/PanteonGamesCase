﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buildingNameText;
    [SerializeField] private Image buildingImage;

    public void Setup()
    {  
        SetActivePanel(false);
        Transform selectable = SelectionManager.Instance.LastSelected;

        if (!selectable.TryGetComponent(out BuildingBase buildingBase))
            return;
        
        SetActivePanel(true);
        buildingNameText.text = buildingBase.PlaceableSo.PlaceableName;
        buildingImage.sprite = buildingBase.PlaceableSo.PlaceableSprite;
    }

    private void SetActivePanel(bool enable)
    {
        buildingNameText.gameObject.SetActive(enable);
        buildingImage.gameObject.SetActive(enable);
    }
}