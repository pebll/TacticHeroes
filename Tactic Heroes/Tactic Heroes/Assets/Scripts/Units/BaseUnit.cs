using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] private Color _playerColor, _enemyColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int BASE_ACTION_SLOTS_AMOUNT;

    public Tile OccupiedTile;
    public int Team { get; private set; } // Starts by 1
    public int Health { get; private set; }
    public bool IsPlayable { get; private set; }
    public string Name { get; private set; }
    public int actionSlotsAmount { get; private set; }

    public List<BaseAction> Actions { get; private set; }

    public BaseAction[] selectedActions { get; private set; }

    public void ExecuteActions()
    {

    }

    public void MoveToTile(Tile tile)
    {
        if (OccupiedTile != null) OccupiedTile.OccupiedUnit = null;
        transform.position = tile.transform.position;
        OccupiedTile = tile;
        tile.OccupiedUnit = this;

    }

    private void SetTeamColor()
    {
        //temporary
        if(Team == 1)
        {
            _spriteRenderer.color = _playerColor;
        }
        else
        {
            _spriteRenderer.color = _enemyColor;
        }
       
    }

    public void Init(int team)
    {
        Name = gameObject.name;
        Team = team;
        updatePlayable();
        SetTeamColor();
        actionSlotsAmount = BASE_ACTION_SLOTS_AMOUNT;
        Health = 3;
        // later class

    }

    private void updatePlayable() {      
        if (Team == Gamemanager.Instance.currentTeam) IsPlayable = true;
        else IsPlayable = false;
    }
}

