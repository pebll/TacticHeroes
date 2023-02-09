using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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
            unit.Init(Random.Range(1, 3));        
        }
    }

    public void SetSelectedUnit(BaseUnit unit)
    {
        SelectedUnit = unit;
        MenuManager.Instance.SetUnitInfoPanel(unit);
    }
}
