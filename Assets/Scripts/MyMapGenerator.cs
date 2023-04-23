using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MyMapGenerator : MonoBehaviour
{
    // tilemap to be drawn on
    public Tilemap tilemap;

    // tiles to be used
    public TileBase grassTile;

    // size of map
    public int width = 60;
    public int height = 40;

    public float modifier = 0.5f;

    public Boolean randomSeed = true;
    public int seed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Generate a map
    void GenerateMap()
    {
        // create a new map
        int[,] map = MapHelpers.GenerateArray(width, height, 0);

        if (randomSeed)
        {
            modifier = UnityEngine.Random.value;
        }
        // add perlin noise to the map
        map = MapHelpers.PerlinNoise(map, modifier);
        // Debug.Log(map);
        // draw the map
        DrawMap(map);
    }

    // Draw the map
    void DrawMap(int[,] map)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (map[x,y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), grassTile);
                }
            }
        }
    }

    void ClearMap()
    {
        tilemap.ClearAllTiles();
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.N))
		{
			ClearMap();
			GenerateMap();
		}
    }
}
