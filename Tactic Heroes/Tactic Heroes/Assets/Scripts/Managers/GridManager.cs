using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _grassTile, _waterTile;
    [SerializeField] private Transform _cam;
    
    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        Instance = this;
    }
    
    public void GenerateGrid()
    {
        _cam.transform.position = new Vector3((float)_width / 2 - .5f, (float)_height / 2 - .5f, -10);
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomTile = Random.Range(0, 3) > 0 ? _grassTile : _waterTile;
                Tile spawnedTile = Instantiate(randomTile, new Vector3(x, y, 0), Quaternion.identity);
                spawnedTile.name = $"Tile ({x}, {y})";
              
                spawnedTile.Init(x,y);

                _tiles.Add(new Vector2(x, y), spawnedTile);
            }
        }
        Gamemanager.Instance.ChangeState(GameState.SpawnUnits);
    }

    public Tile GetTile(Vector2 position)
    {
        if (_tiles.ContainsKey(position))
        {
            return _tiles[position];
        }
        return null;
    }

    public Tile GetRandomTile()
    {
        return _tiles.Where(t => t.Value.IsWalkable).OrderBy(t => Random.value).First().Value;
    }
}
