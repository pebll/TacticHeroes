using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableClass> _classes;
    [SerializeField] private GameObject _unitPrefab;

    public BaseUnit SelectedUnit;

    void Awake()
    {
        Instance = this;
        _classes = Resources.LoadAll<ScriptableClass>("ScriptableClasses").ToList();
    }

    public void SpawnUnits()
    {
        //temporary
        var count = 4;
        for (int i = 0; i < count; i++)
        {
            var unitObject = Instantiate(_unitPrefab);
            var randomSpawnTile = GridManager.Instance.GetRandomTile();
            BaseUnit unit = unitObject.GetComponent<BaseUnit>();
            unit.MoveToTile(randomSpawnTile);
            unit.Faction = Faction.Player;
            if (i % 2 == 0) unit.Faction = Faction.Enemy;
            
        }
    }

    public void SetSelectedUnit(BaseUnit unit)
    {
        SelectedUnit = unit;
    }
}
