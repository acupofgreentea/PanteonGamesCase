using System.Collections.Generic;
using UnityEngine;

public class BuildingSoldierSpawner : MonoBehaviour
{
    [SerializeField] private BuildingSoldierSpawnStatSO soldierSpawnStatSo;
    
    private BuildingBase buildingBase;

    private float lastSpawnTime;

    private List<SoldierUnit> activeSoldiers = new List<SoldierUnit>();

    private SoldierPool soldierPool;

    [SerializeField] private Transform spawnPoint;

    public BuildingSoldierSpawner Init(BuildingBase buildingBase)
    {
        this.buildingBase = buildingBase;
        
        return this;
    }

    private void Start()
    {
        soldierPool = SoldierPool.Instance;
        soldierPool.OnReturnToPool += HandleOnSoldierDie;
    }
    private bool HasReachedMaxCapacity => activeSoldiers.Count >= soldierSpawnStatSo.MaxCount;

    private void Update()
    {
        if (HasReachedMaxCapacity)
            return;

        if (!(Time.time >= lastSpawnTime + soldierSpawnStatSo.SpawnRate)) 
            return;
        
        lastSpawnTime = Time.time;

        SpawnSoldier();
    }

    private void SpawnSoldier()
    {
        SoldierUnit newSoldier = soldierPool.Get();

        activeSoldiers.Add(newSoldier);

        newSoldier.transform.position = spawnPoint.position;
    }

    private void HandleOnSoldierDie(SoldierUnit soldierUnit)
    {
        activeSoldiers.Remove(soldierUnit);
    }
}