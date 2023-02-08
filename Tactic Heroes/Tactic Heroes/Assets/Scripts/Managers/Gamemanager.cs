using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;
    public GameState GameState;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.ChooseUnits:
                break;
            case GameState.SpawnUnits:
                UnitManager.Instance.SpawnUnits();
                break;
            case GameState.ChooseActions:
                break;
            case GameState.ResolveActions:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    ChooseUnits = 1,
    SpawnUnits = 2,
    ChooseActions = 3,
    ResolveActions = 4
}
