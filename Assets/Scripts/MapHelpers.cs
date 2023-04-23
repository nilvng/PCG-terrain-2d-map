using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapHelpers {
    public static int[,] PerlinNoise(int[,] map, float modifier)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                map[x,y] = Mathf.RoundToInt(Mathf.PerlinNoise(x * modifier, y * modifier));
            }
        }
        return map;
    }

    public static int[,] GenerateArray(int width, int height, int value)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x,y] = value;
            }
        }
        return map;
    }
}