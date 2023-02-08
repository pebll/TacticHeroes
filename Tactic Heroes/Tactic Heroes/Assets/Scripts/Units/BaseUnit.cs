using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public Tile OccupiedTile;
    public void MoveToTile(Tile tile)
    {
        if (OccupiedTile != null) OccupiedTile.OccupiedUnit = null;
        transform.position = tile.transform.position;
        OccupiedTile = tile;
        tile.OccupiedUnit = this;

    }
}
