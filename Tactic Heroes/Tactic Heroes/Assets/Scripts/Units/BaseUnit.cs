using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public Tile OccupiedTile;
    public Faction Faction;
    [SerializeField] private Color _playerColor, _enemyColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start() {
        SetFactionColor();
    }

    public void MoveToTile(Tile tile)
    {
        if (OccupiedTile != null) OccupiedTile.OccupiedUnit = null;
        transform.position = tile.transform.position;
        OccupiedTile = tile;
        tile.OccupiedUnit = this;

    }

    public void SetFactionColor()
    {
        //temporary
        if(Faction == Faction.Player)
        {
            _spriteRenderer.color = _playerColor;
        }
        else
        {
            _spriteRenderer.color = _enemyColor;
        }
       
    }
}

