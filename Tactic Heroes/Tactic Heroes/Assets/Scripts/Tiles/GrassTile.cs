using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{

    [SerializeField] private Color _lightColor, _darkColor;
    public override void Init(int x, int y)
    {
        bool isOffset = (x + y) % 2 == 1;
        _spriteRenderer.color = isOffset ? _lightColor : _darkColor;
    }
}
