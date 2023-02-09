using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private UnitInfoPanel _unitInfoPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void SetUnitInfoPanel(BaseUnit unit)
    {
        _unitInfoPanel.SetUnit(unit);
    }


}
