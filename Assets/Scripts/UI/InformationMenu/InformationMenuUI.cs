using UnityEngine;

public class InformationMenuUI : MonoBehaviour
{
    [SerializeField] private ProductionInfoUI productionInfoUI;
    [SerializeField] private BuildingInfoUI buildingInfoUI;

    //game event func in inspector
    public void HandleSelectableSelectedEvent()
    {
        buildingInfoUI.Setup();
        productionInfoUI.Setup();
    }
}